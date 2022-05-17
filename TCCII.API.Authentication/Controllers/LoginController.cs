using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TCCII.API.Authentication.API.DTOs.RequestModels.Login;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Common;
using TCCII.API.Authentication.API.DTOs.ResponseModels.Login;
using TCCII.API.Authentication.API.Intefaces;

namespace TCCII.API.Authentication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Login de Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<LoginResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse<object>))]
        public async Task<IActionResult> Login([FromBody, SwaggerParameter(Required = true)] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(CustomResponse<ErrorResponse>.FromErrorModelState(ModelState));

            var result = await _loginServices.Login(request);
            if (result.Success)
                return Ok(result);

            return Unauthorized(result);

        }
    }
}
