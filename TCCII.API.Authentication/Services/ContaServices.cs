using AutoMapper;
using System.Net;
using TCCII.API.Authentication.API.DTOs.RequestModels.Account;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Account;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.Intefaces;
using TCCII.API.Authentication.API.Messages;
using TCCII.API.Authentication.API.Models;
using TCCII.Core.Entities.Identity;
using TCCII.Core.Interfaces;

namespace TCCII.API.Authentication.API.Services
{
    public class ContaServices : IContaServices
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;

        public ContaServices(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateUserResponse>> AddAccount(CreateUserRequest request)
        {
            UserModel userModel = _mapper.Map<UserModel>(request);
            User userIdentity = _mapper.Map<User>(userModel);

            var result = await _userServices.CreateUser(userIdentity, request.Password);

            if (result.Succeeded)
            {
                var user = await _userServices.GetUserByEmail(request.Email);

                return CustomResponse<CreateUserResponse>.FromSuccess(
                    new CreateUserResponse { Id = user.Id, User = user.UserName },
                    HttpStatusCode.Created.ToString(),
                    StatusCodes.Status201Created);
            }

            return CustomResponse<CreateUserResponse>.FromBadRequest(
                ErrorResponse.From(result, MessageInstanceFailed.FailedRegisterUser));

        }
    }
}
