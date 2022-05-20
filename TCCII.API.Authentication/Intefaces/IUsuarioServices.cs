using TCCII.Deputados.API.DTOs.RequestModels.Usuarios;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;

namespace TCCII.Deputados.API.Intefaces
{
    public interface IUsuarioServices
    {
        Task<CustomResponse<MessageResponse>> FollowDeputado(FollowDeputadoRequest request);
        Task<CustomResponse<MessageResponse>> UnfollowDeputado(UnfollowDeputadoRequest request);
    }
}
