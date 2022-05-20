using TCCII.Deputados.API.DTOs.RequestModels.Account;
using TCCII.Deputados.API.DTOs.ResponseModels.Account;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;

namespace TCCII.Deputados.API.Intefaces
{
    public interface IContaServices
    {
        Task<CustomResponse<CreateUserResponse>> AddAccount(CreateUserRequest request);
        Task<CustomResponse<MessageResponse>> ChangePassword(ChangePasswordRequest request);
    }
}
