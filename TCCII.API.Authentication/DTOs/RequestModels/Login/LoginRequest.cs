using System.ComponentModel.DataAnnotations;

namespace TCCII.Deputados.API.DTOs.RequestModels.Login
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
