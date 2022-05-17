using TCCII.API.Authentication.API.DTOs.RequestModels.Account;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Account;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;

namespace TCCII.API.Authentication.API.Intefaces
{
    public interface IContaServices
    {
        Task<CustomResponse<CreateUserResponse>> AddAccount(CreateUserRequest request);
    }
}
