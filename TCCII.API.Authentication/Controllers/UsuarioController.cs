using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.Deputados.API.DTOs.RequestModels.Usuarios;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;
using TCCII.Deputados.API.Intefaces;

namespace TCCII.Deputados.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpPost]
        [Route("deputado/follow")]
        [SwaggerOperation(Summary = "Seguir Deputado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> FollowDeputado([FromBody, SwaggerParameter(Required = true)] FollowDeputadoRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _usuarioServices.FollowDeputado(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }
        
        [HttpPost]
        [Route("deputado/unfollow")]
        [SwaggerOperation(Summary = "Deixar de seguir Deputado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> UnfollowDeputado([FromBody, SwaggerParameter(Required = true)] UnfollowDeputadoRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _usuarioServices.UnfollowDeputado(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }

        [HttpGet]
        [Route("deputado/following")]
        [SwaggerOperation(Summary = "Retorna deputados seguidos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<DeputadosResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> DeputadoFollowing([FromQuery, SwaggerParameter(Required = true)] string userName)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _usuarioServices.GetDeputadoFollowing(userName);
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }
    }
}
