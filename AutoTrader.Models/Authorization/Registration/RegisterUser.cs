using System.ComponentModel.DataAnnotations;

namespace AutoTrader.Models.Authorization.Registration
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        public string? Role { get; set; }


    }
}
