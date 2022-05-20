using System.ComponentModel.DataAnnotations;

namespace TCCII.Deputados.API.DTOs.RequestModels.Account
{
    public class ChangePasswordRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


    }
}
