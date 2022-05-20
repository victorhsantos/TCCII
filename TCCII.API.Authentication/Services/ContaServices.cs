using AutoMapper;
using System.Net;
using TCCII.Deputados.API.DTOs.RequestModels.Account;
using TCCII.Deputados.API.DTOs.ResponseModels.Account;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.API.Models;
using TCCII.Deputados.Core.Entities.Identity;
using TCCII.Deputados.Core.Interfaces;

namespace TCCII.Deputados.API.Services
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

        public async Task<CustomResponse<MessageResponse>> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _userServices.GetUserByUserName(request.UserName);
            if (user == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.UserNotFound));

            var passwordIsValid = await _userServices.CheckPasswordUser(user, request.Password);
            if (!passwordIsValid) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.InvalidPassword));

            var result = await _userServices.ChangePassword(user, request.Password, request.NewPassword);
            if (!result.Succeeded) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.FailedChangePassword));

            return CustomResponse<MessageResponse>.FromSuccess(MessageResponse.Success(MessageInstanceSuccess.SuccessChangePassword));
        }
    }
}
