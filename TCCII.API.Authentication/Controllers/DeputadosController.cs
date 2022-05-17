using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.API.Authentication.API.DTOs.RequestModels.Deputados;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Deputados;
using TCCII.API.Authentication.API.Intefaces;

namespace TCCII.API.Authentication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DeputadosController : ControllerBase
    {
        private readonly IDeputadosServices _deputadosServices;

        public DeputadosController(IDeputadosServices deputadosServices)
        {
            _deputadosServices = deputadosServices;
        }

        [HttpPost]
        [Route("create")]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<DeputadosResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> Get()
        {            
            var result = await _deputadosServices.GetAllDeputados();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
