using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.API.DTOs.RequestModels.Usuarios;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.Core.Interfaces;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;
using AutoMapper;

namespace TCCII.Deputados.API.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserServices _userServices;


        public UsuarioServices(
            IUserServices userServices, 
            IUnitOfWork uow, 
            IMapper mapper)
        {
            _userServices = userServices;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CustomResponse<MessageResponse>> FollowDeputado(FollowDeputadoRequest request)
        {
            var deputado = _uow.DeputadosRepository.QueryableFor(d => d.IdDeputado == request.IdDeputado).FirstOrDefault();
            if (deputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var user = await _userServices.GetUserByUserName(request.UserName);
            if (user == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.UserNotFound));

            var result = await _uow.UserDeputadosRepository.Add(new UserDeputados(user.Id, deputado.Id));
            if (result == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.FailedFollowDeputado));

            _uow.Commit();
            return CustomResponse<MessageResponse>.FromSuccess(MessageResponse.Success(MessageInstanceSuccess.SuccessFollowDeputado));

        }

        public async Task<CustomResponse<List<DeputadosResponse>>> GetDeputadoFollowing(string userName)
        {
            var user = await _userServices.GetUserByUserName(userName);
            if (user == null) return CustomResponse<List<DeputadosResponse>>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.UserNotFound));

            var deputadoFollowing = _mapper.Map<List<DeputadosResponse>>(_userServices.GetFollowDeputados(user));
            return CustomResponse<List<DeputadosResponse>>.FromSuccess(deputadoFollowing);
        }

        public async Task<CustomResponse<MessageResponse>> UnfollowDeputado(UnfollowDeputadoRequest request)
        {
            var deputado = _uow.DeputadosRepository.QueryableFor(d => d.IdDeputado == request.IdDeputado).FirstOrDefault();
            if (deputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var user = await _userServices.GetUserByUserName(request.UserName);
            if (user == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.UserNotFound));

            var userDeputados = _uow.UserDeputadosRepository.QueryableFor(x => x.UserId == user.Id);

            var userDeputado = userDeputados.Where(x => x.DeputadosId == deputado.Id).FirstOrDefault();
            if (userDeputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var result = _uow.UserDeputadosRepository.Remove(userDeputado);
            if (result == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.FailedFollowDeputado));

            _uow.Commit();
            return CustomResponse<MessageResponse>.FromSuccess(MessageResponse.Success(MessageInstanceSuccess.SuccessUnfollowDeputado));
        }
    }
}
