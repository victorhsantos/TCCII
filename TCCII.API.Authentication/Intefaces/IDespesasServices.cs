using TCCII.Deputados.API.DTOs.RequestModels.Despesas;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Despesas;

namespace TCCII.Deputados.API.Intefaces
{
    public interface IDespesasServices
    {
        Task<CustomResponse<MessageResponse>> AddDespesas(CreateDespesasRequest request);
        Task<CustomResponse<NewsDespesasResponse>> GetNewsDespesas(int idDeputado);
    }
}
