using TCCII.API.Authentication.API.DTOs.RequestModels.Login;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Login;

namespace TCCII.API.Authentication.API.Intefaces
{
    public interface ILoginServices
    {
        Task<CustomResponse<LoginResponse>> Login(LoginRequest request);
    }
}
