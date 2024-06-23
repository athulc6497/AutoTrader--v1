using AutoTrader.Models.Authorization.Login;
using AutoTrader.Models.Authorization.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Response = AutoTrader.Api.Models.Response;

namespace AutoTrader.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthenticationController(UserManager<IdentityUser> userManager,
         RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
    {
        //Check User Exist in DB

        var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
        if (userExist != null)
        {
            return StatusCode(StatusCodes.Status403Forbidden,
                new Response { Status = "Error", Message = "User already Exists" });
            }


        //Add User In db
        IdentityUser user = new()
        {
            Email = registerUser.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registerUser.UserName
        };

        if (await _roleManager.RoleExistsAsync(registerUser.Role))
        {
            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User Failed To Create" });

                }
            // Add role to user
            await _userManager.AddToRoleAsync(user, registerUser.Role);

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "User created Sucessfully" });
            }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "This Role does not exist" });
            }
    }
    [HttpPost]
    [Route("login")]

    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {

        try
        {
            //CHECK THE USER

            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            //CHECK THE PASSWORD

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                //CREATE A CLAIM LIST

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),


                };


                //WE ADD ROLES TO THE  CLAIM LIST

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));

                }


                //GENERATE THE TOKENS WITH THE CLAIMS

                var jwtToken = GetToken(authClaims);

                return Ok(new LoginResponse
                {

                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    Expiration = jwtToken.ValidTo

                });


                //RETURNING THE TOKEN
            }
            return Unauthorized();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }
    }
}
