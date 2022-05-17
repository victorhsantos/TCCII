using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.API.Authentication.API.DTOs.RequestModels.Account;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Account;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.Intefaces;

namespace TCCII.API.Authentication.Controllers
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
    }
}
