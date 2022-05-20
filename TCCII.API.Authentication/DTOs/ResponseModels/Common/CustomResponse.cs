using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace TCCII.Deputados.API.DTOs.ResponseModels.Common
{
    public class CustomResponse<T>
    {
        public bool Success { get; set; }
        public ErrorResponse Errors { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public static CustomResponse<T> From(bool success, T data, string message, int statusCode = StatusCodes.Status200OK, ErrorResponse errors = null)
        {
            return new CustomResponse<T>
            {
                Success = success,
                Errors = errors,
                Data = data,
                Message = message,
                StatusCode = statusCode,
            };
        }
        public static CustomResponse<T> FromSuccess(T data, string message = "Ok", int statusCode = StatusCodes.Status200OK)
        {
            return new CustomResponse<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = statusCode,
            };
        }

        public static CustomResponse<T> FromBadRequest(ErrorResponse errors)
        {
            return new CustomResponse<T>
            {
                Success = false,
                Errors = errors,
                Message = HttpStatusCode.BadRequest.ToString(),
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }

        public static CustomResponse<T> FromErrorModelState(ModelStateDictionary modelState)
        {
            return new CustomResponse<T>
            {
                Success = false,
                Errors = ErrorResponse.ModelState(modelState),
                Message = HttpStatusCode.BadRequest.ToString(),
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

    }
}
