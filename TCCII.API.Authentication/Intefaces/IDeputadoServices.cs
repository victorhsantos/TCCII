using TCCII.Deputados.API.DTOs.RequestModels.Deputados;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;

namespace TCCII.Deputados.API.Intefaces
{
    public interface IDeputadoServices
    {
        Task<CustomResponse<MessageResponse>> AddDeputados(List<CreateDeputadosRequest> request);
        Task<CustomResponse<List<DeputadosResponse>>> GetAllDeputados();
        Task<CustomResponse<DeputadosResponse>> GetDeputado(int idDeputado);
    }
}
