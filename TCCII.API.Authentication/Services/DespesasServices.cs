using AutoMapper;
using System.Net;
using TCCII.Deputados.API.DTOs.RequestModels.Despesas;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Despesas;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;

namespace TCCII.Deputados.API.Services
{
    public class DespesasServices : IDespesasServices
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public DespesasServices(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CustomResponse<MessageResponse>> AddDespesas(CreateDespesasRequest request)
        {
            var deputado = _uow.DeputadosRepository.QueryableFor(d => d.IdDeputado == request.DeputadoID).FirstOrDefault();
            if (deputado == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            foreach (var itemDespesa in request.Despesas)
            {
                var newDespesa = _mapper.Map<Despesa>(itemDespesa);
                newDespesa.IdDeputado = deputado.IdDeputado;

                var despesa = await _uow.DespesasRepository.Add(newDespesa);
                if (despesa == null) return CustomResponse<MessageResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.FailedFollowDeputado));
            }
            _uow.Commit();

            return CustomResponse<MessageResponse>.FromSuccess(
                                MessageResponse.Success(MessageInstanceSuccess.SuccessCreateDeputados),
                                HttpStatusCode.Created.ToString(),
                                StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<NewsDespesasResponse>> GetNewsDespesas(int idDeputado)
        {
            var deputado = _uow.DeputadosRepository.QueryableFor(d => d.IdDeputado == idDeputado).FirstOrDefault();
            if (deputado == null) return CustomResponse<NewsDespesasResponse>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var despesas = _uow.DespesasRepository.QueryableFor(x => x.IdDeputado == deputado.IdDeputado).Where(n => n.notificada == 0).ToList();
            if (despesas == null) return CustomResponse<NewsDespesasResponse>.FromSuccess(new NewsDespesasResponse());


            var despesasResponse = new NewsDespesasResponse();
            foreach (var despesa in despesas)
            {
                despesasResponse.Despesas.Add(_mapper.Map<DespesaResponse>(despesa));
                despesa.notificada = 1;
                _uow.DespesasRepository.Update(despesa);
            }
            _uow.Commit();

            return CustomResponse<NewsDespesasResponse>.FromSuccess(despesasResponse);
        }

        public async Task<CustomResponse<List<DespesaResponse>>> GetDespesas(int idDeputado)
        {
            var deputado = _uow.DeputadosRepository.QueryableFor(d => d.IdDeputado == idDeputado).FirstOrDefault();
            if (deputado == null) return CustomResponse<List<DespesaResponse>>.FromBadRequest(ErrorResponse.BadRequest(MessageInstanceFailed.DeputadoNotFound));

            var despesas = _uow.DespesasRepository.QueryableFor(x => x.IdDeputado == deputado.IdDeputado).ToList();
            if (despesas == null) return CustomResponse<List<DespesaResponse>>.FromSuccess(new List<DespesaResponse>());

            var despesasResponse = new List<DespesaResponse>();
            foreach (var despesa in despesas)
                despesasResponse.Add(_mapper.Map<DespesaResponse>(despesa));

            return CustomResponse<List<DespesaResponse>>.FromSuccess(despesasResponse);
        }
    }
}
