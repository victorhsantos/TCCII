using AutoMapper;
using System.Net;
using TCCII.Deputados.API.DTOs.RequestModels.Login;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;
using TCCII.Deputados.API.DTOs.ResponseModels.Login;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.Core.Interfaces;

namespace TCCII.Deputados.API.Services
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
                var followDeputados = _mapper.Map<List<DeputadosResponse>>(_userServices.GetFollowDeputados(user));

                return CustomResponse<LoginResponse>.FromSuccess(
                    new LoginResponse
                    {
                        Id = user.Id,
                        User = user.UserName,
                        FullName = user.FullName,
                        //TokenAccess = _tokenServices.GenerateJWT(user, role.First()).ToString(),
                        FollowDeputados = followDeputados
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

