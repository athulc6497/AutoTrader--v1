using System.ComponentModel.DataAnnotations;

namespace AutoTrader.Models.Authorization.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string? Password { get; set; }

    }
}
