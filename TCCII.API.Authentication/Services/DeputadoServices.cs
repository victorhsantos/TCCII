using AutoMapper;
using System.Net;
using TCCII.Deputados.API.DTOs.RequestModels.Deputados;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;
using TCCII.Deputados.API.Intefaces;
using TCCII.Deputados.API.Messagens;
using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;

namespace TCCII.Deputados.API.Services
{
    public class DeputadosServices : IDeputadoServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public DeputadosServices(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;            
            _uow = uow;
        }

        public async Task<CustomResponse<MessageResponse>> AddDeputados(List<CreateDeputadosRequest> request)
        {
            foreach (var requestItem in request)
            {
                if (string.IsNullOrEmpty(requestItem.nome)) continue;

                var deputado = _mapper.Map<Deputado>(requestItem);
                await _uow.DeputadosRepository.Add(deputado);
            }

            _uow.Commit();

            return CustomResponse<MessageResponse>.FromSuccess(
                                MessageResponse.Success(MessageInstanceSuccess.SuccessCreateDeputados),
                                HttpStatusCode.Created.ToString(),
                                StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<DeputadosResponse>>> GetAllDeputados()
        {
            var deputados = _uow.DeputadosRepository.QueryableFor(orderBy: x => x.OrderBy(a => a.Nome)).ToList();

            List<DeputadosResponse> result = new List<DeputadosResponse>();

            foreach (var deputado in deputados)
                result.Add(_mapper.Map<DeputadosResponse>(deputado));

            return CustomResponse<List<DeputadosResponse>>.FromSuccess(
                                result,
                                HttpStatusCode.OK.ToString(),
                                StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<DeputadosResponse>> GetDeputado(int idDeputado)
        {
            var deputado = _uow.DeputadosRepository.QueryableFor(x => x.IdDeputado == idDeputado).FirstOrDefault();
            var result = _mapper.Map<DeputadosResponse>(deputado);

            return CustomResponse<DeputadosResponse>.FromSuccess(
                                result,
                                HttpStatusCode.OK.ToString(),
                                StatusCodes.Status200OK);
        }
    }
}
