using System.ComponentModel.DataAnnotations;

namespace TCCII.API.Authentication.API.DTOs.RequestModels.Account
{
    public class CreateUserRequest
    {        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
