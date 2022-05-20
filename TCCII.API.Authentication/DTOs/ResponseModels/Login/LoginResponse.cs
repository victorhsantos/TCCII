using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;

namespace TCCII.Deputados.API.DTOs.ResponseModels.Login
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string FullName { get; set; }
        public string TokenAccess { get; set; }
        public List<DeputadosResponse> FollowDeputados { get; set; }

    }
}
