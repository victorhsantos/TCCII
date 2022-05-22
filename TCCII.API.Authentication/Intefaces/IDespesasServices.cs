using TCCII.Deputados.API.DTOs.RequestModels.Despesas;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;

namespace TCCII.Deputados.API.Intefaces
{
    public interface IDespesasServices
    {
        Task<CustomResponse<MessageResponse>> AddDespesas(CreateDespesasRequest request);
    }
}
