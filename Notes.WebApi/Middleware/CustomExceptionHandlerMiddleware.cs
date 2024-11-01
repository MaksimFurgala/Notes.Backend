using System.Net;
using FluentValidation;
using Notes.Application.Common.Exceptions;

namespace Notes.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Выполение обработчика middleware.
        /// </summary>
        /// <param name="httpContext"></param>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Выполнение асинхронного обработчика в случае ошибок.
        /// </summary>
        /// <param name="httpContext">контекст</param>
        /// <param name="ex">exception</param>
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = new object();
            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = validationException.Errors;
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                default:
                    result = new { error = ex.Message };
                    break;
            }

            httpContext.Response.StatusCode = (int)code;

            await httpContext.Response.WriteAsJsonAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        // Метод расширения для встаивания middleware в HTTP pipeline.
        public static void UseCustomExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}