using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.API.DTOs.RequestModels.Usuarios;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.Core.Interfaces;
using TCCII.Deputados.Core.Interfaces.Repositories;

namespace TCCII.Deputados.API.Services
{
    public class UsuarioServices : IUsuarioServices
    {

        private readonly IUserServices _userServices;
        private readonly IDeputadosRepository _deputadosRepository;
        private readonly IUserDeputadosRepository _userDeputadosRepository;

        public UsuarioServices(IUserDeputadosRepository userDeputadosRepository, IDeputadosRepository deputadosRepository, IUserServices userServices)
        {
            _userDeputadosRepository = userDeputadosRepository;
            _deputadosRepository = deputadosRepository;
            _userServices = userServices;
        }

        public async Task<CustomResponse<MessageResponse>> FollowDeputado(FollowDeputadoRequest request)
        {
            var deputado = _deputadosRepository.QueryableFor(d => d.IdDeputado == request.IdDeputado).FirstOrDefault();
            if (deputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var user = await _userServices.GetUserByUserName(request.UserName);
            if (user == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.UserNotFound));

            var result = await _userDeputadosRepository.Add(new UserDeputados(user.Id, deputado.Id));
            if (result == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.FailedFollowDeputado));

            await _userDeputadosRepository.Save();
            return CustomResponse<MessageResponse>.FromSuccess(MessageResponse.Success(MessageInstanceSuccess.SuccessFollowDeputado));

        }

        public async Task<CustomResponse<MessageResponse>> UnfollowDeputado(UnfollowDeputadoRequest request)
        {
            var deputado = _deputadosRepository.QueryableFor(d => d.IdDeputado == request.IdDeputado).FirstOrDefault();
            if (deputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var user = await _userServices.GetUserByUserName(request.UserName);
            if (user == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.UserNotFound));

            var userDeputados = _userDeputadosRepository.QueryableFor(x => x.UserId == user.Id);

            var userDeputado = userDeputados.Where(x => x.DeputadosId == deputado.Id).FirstOrDefault();
            if (userDeputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var result = _userDeputadosRepository.Remove(userDeputado);
            if (result == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.FailedFollowDeputado));

            await _userDeputadosRepository.Save();
            return CustomResponse<MessageResponse>.FromSuccess(MessageResponse.Success(MessageInstanceSuccess.SuccessUnfollowDeputado));
        }
    }
}
