using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.Deputados.API.DTOs.RequestModels.Deputados;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Deputados;
using TCCII.Deputados.API.Intefaces;

namespace TCCII.Deputados.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DeputadosController : ControllerBase
    {
        private readonly IDeputadoServices _deputadosServices;

        public DeputadosController(IDeputadoServices deputadosServices)
        {
            _deputadosServices = deputadosServices;
        }

        [HttpPost]        
        [SwaggerOperation(Summary = "Cadastra Deputados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> CreateDeputados([FromBody, SwaggerParameter(Required = true)] List<CreateDeputadosRequest> request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _deputadosServices.AddDeputados(request);
            if (result.Success) return Created("", result);
            return BadRequest(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todos os Deputados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<DeputadosResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _deputadosServices.GetAllDeputados();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{idDeputado}")]
        [SwaggerOperation(Summary = "Retorna Deputado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<DeputadosResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> GetDeputado(int idDeputado)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _deputadosServices.GetDeputado(idDeputado);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
