using TCCII.Deputados.API.DTOs.RequestModels.Login;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Login;

namespace TCCII.Deputados.API.Intefaces
{
    public interface ILoginServices
    {
        Task<CustomResponse<LoginResponse>> Login(LoginRequest request);
    }
}
