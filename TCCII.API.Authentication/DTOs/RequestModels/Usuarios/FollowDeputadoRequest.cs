using System.ComponentModel.DataAnnotations;

namespace TCCII.Deputados.API.DTOs.RequestModels.Usuarios
{
    public class FollowDeputadoRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public int IdDeputado { get; set; }
    }
}
