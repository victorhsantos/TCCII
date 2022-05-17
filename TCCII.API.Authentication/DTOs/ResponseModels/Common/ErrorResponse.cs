using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TCCII.API.Authentication.API.Messages;

namespace TCCII.API.Authentication.API.DTOs.ResponseModels.Common
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string ErrorMsg { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }

        private const string Message_Defaut = "O servidor não conseguiu entender a requisição devido à parâmetros inválidos.";

        public static ErrorResponse From(Exception ex)
        {
            if (ex == null) return null;

            return new ErrorResponse
            {
                Code = ex.HResult,
                ErrorMsg = ex.Message,
                InnerError = ErrorResponse.From(ex.InnerException)
            };
        }

        public static ErrorResponse From(IdentityResult result, MessageInstanceFailed instance)
        {
            if (result == null) return null;

            return new ErrorResponse
            {
                Code = (int)instance,
                ErrorMsg = instance.GetDescription(),
                Details = result.Errors.Select(e => e.Description).ToArray()

            };
        }

        public static ErrorResponse ModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);

            return new ErrorResponse
            {
                Code = 4000,
                ErrorMsg = Message_Defaut,
                Details = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }

        public static ErrorResponse BadRequest(MessageInstanceFailed instance)
        {
            return new ErrorResponse
            {
                Code = (int)instance,
                ErrorMsg = instance.GetDescription()
            };
        }        
    }
}
