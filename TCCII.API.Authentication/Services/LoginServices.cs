using AutoMapper;
using System.Net;
using TCCII.API.Authentication.API.DTOs.RequestModels.Login;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Login;
using TCCII.API.Authentication.API.Intefaces;
using TCCII.API.Authentication.API.Messages;
using TCCII.Core.Interfaces;

namespace TCCII.API.Authentication.API.Services
{

    public class LoginServices : ILoginServices
    {

        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;
        //private readonly ITokenServices _tokenServices;

        public LoginServices(IMapper mapper, IUserServices userServices)
        {
            _mapper = mapper;
            _userServices = userServices;
        }


        public async Task<CustomResponse<LoginResponse>> Login(LoginRequest request)
        {
            var resultIdentity = await _userServices.SingInAccontUser(request.UserName, request.Password);

            if (resultIdentity)
            {
                var user = await _userServices.GetUserByUserName(request.UserName);
                
                return CustomResponse<LoginResponse>.FromSuccess(
                    new LoginResponse
                    {
                        Id = user.Id,
                        User = user.UserName,
                        FullName = user.FullName,
                        //TokenAccess = _tokenServices.GenerateJWT(user, role.First()).ToString(),                        
                    });
            }

            return CustomResponse<LoginResponse>.From(
                resultIdentity,
                null,
                HttpStatusCode.Unauthorized.ToString(),
                StatusCodes.Status401Unauthorized,
                ErrorResponse.From(new Exception(MessageInstanceFailed.InvalidUserOrPassword.GetDescription())));
        }
    }
}

