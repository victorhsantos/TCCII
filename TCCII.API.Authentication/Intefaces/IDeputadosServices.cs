using TCCII.API.Authentication.API.DTOs.RequestModels.Deputados;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Deputados;

namespace TCCII.API.Authentication.API.Intefaces
{
    public interface IDeputadosServices
    {
        Task<CustomResponse<MessageResponse>> AddDeputados(List<CreateDeputadosRequest> request);
        Task<CustomResponse<List<DeputadosResponse>>> GetAllDeputados();
    }
}
