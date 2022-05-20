using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.Deputados.API.DTOs.RequestModels.Account;
using TCCII.Deputados.API.DTOs.ResponseModels.Account;
using TCCII.Deputados.API.DTOs.ResponseModels.Common;
using TCCII.Deputados.API.Intefaces;

namespace TCCII.Deputados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaServices _contaServices;

        public ContaController(IContaServices contaServices)
        {
            _contaServices = contaServices;
        }

        [HttpPost]
        [Route("create")]
        [SwaggerOperation(Summary = "Cadastrar usuário")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<CreateUserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> RegisterAccount([FromBody, SwaggerParameter(Required = true)] CreateUserRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _contaServices.AddAccount(request);
            if (result.Success) return Created("", result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("change/password")]
        [SwaggerOperation(Summary = "Altera Senha")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> ChangePassword([FromBody, SwaggerParameter(Required = true)] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _contaServices.ChangePassword(request);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
