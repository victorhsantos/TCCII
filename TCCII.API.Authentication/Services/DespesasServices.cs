using AutoMapper;
using System.Net;
using TCCII.Deputados.API.DTOs.RequestModels.Despesas;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Interfaces.Repositories;
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
    }
}
