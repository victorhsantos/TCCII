using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.Deputados.API.DTOs.RequestModels.Despesas;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.DTOs.ResponseModels.Despesas;
using TCCII.Deputados.API.Intefaces;

namespace TCCII.Deputados.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesasServices _despesasServices;

        public DespesasController(IDespesasServices despesasServices)
        {
            _despesasServices = despesasServices;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra Despesas para um deputado.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> CreateDespesas([FromBody, SwaggerParameter(Required = true)] CreateDespesasRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _despesasServices.AddDespesas(request);
            if (result.Success) return Created("", result);
            return BadRequest(result);
        }

        [HttpGet("{idDeputado}")]
        [SwaggerOperation(Summary = "Retorna atualizacoes nas despesas do deputado.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<List<DespesaResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> Despesas(int idDeputado)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _despesasServices.GetDespesas(idDeputado);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("news/{idDeputado}")]
        [SwaggerOperation(Summary = "Retorna atualizacoes nas despesas do deputado.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<NewsDespesasResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> NewsDespesas(int idDeputado)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _despesasServices.GetNewsDespesas(idDeputado);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
