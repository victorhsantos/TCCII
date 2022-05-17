using AutoMapper;
using System.Net;
using TCCII.API.Authentication.API.DTOs.RequestModels.Deputados;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Deputados;
using TCCII.API.Authentication.API.Intefaces;
using TCCII.API.Authentication.API.Messages;
using TCCII.Core.Entities;
using TCCII.Core.Interfaces.Repositories;

namespace TCCII.API.Authentication.API.Services
{
    public class DeputadosServices : IDeputadosServices
    {
        private readonly IMapper _mapper;
        private readonly IDeputadosRepository _deputadosRepository;

        public DeputadosServices(IMapper mapper, IDeputadosRepository deputadosRepository)
        {
            _mapper = mapper;
            _deputadosRepository = deputadosRepository;
        }

        public async Task<CustomResponse<MessageResponse>> AddDeputados(List<CreateDeputadosRequest> request)
        {
            foreach (var requestItem in request)
            {
                if (String.IsNullOrEmpty(requestItem.nome)) continue;

                var deputado = _mapper.Map<Deputados>(requestItem);
                await _deputadosRepository.Add(deputado);
            }

            await _deputadosRepository.Save();

            return CustomResponse<MessageResponse>.FromSuccess(
                                MessageResponse.Success(MessageInstanceSuccess.SuccessCreateDeputados),
                                HttpStatusCode.Created.ToString(),
                                StatusCodes.Status201Created);
        }

        public async Task<CustomResponse<List<DeputadosResponse>>> GetAllDeputados()
        {
            var deputados = _deputadosRepository.QueryableFor(orderBy: x => x.OrderBy(a => a.Nome)).ToList();
            
            List<DeputadosResponse> result = new List<DeputadosResponse>();
            
            foreach (var deputado in deputados)            
                result.Add(_mapper.Map<DeputadosResponse>(deputado));
            
            return CustomResponse<List<DeputadosResponse>>.FromSuccess(
                                result,
                                HttpStatusCode.OK.ToString(),
                                StatusCodes.Status200OK);
        }
    }
}
