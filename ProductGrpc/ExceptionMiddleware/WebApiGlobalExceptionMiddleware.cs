using gRPC_Helper.ExceptionHandler;
using gRPC_Shared.ViewModels;
using System.Net;

namespace ProductGrpc.ExceptionMiddleware
{
	public class WebApiGlobalExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IHostEnvironment _env;
		private readonly ILogger<WebApiGlobalExceptionMiddleware> _logger;

		public WebApiGlobalExceptionMiddleware(RequestDelegate next,
			ILogger<WebApiGlobalExceptionMiddleware> logger,
			IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}
		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (CustomException ce)
			{
				// we don't log any messages, because we know this is a business error.
				var responseVM = new ResponseViewModel
				{
					Code = ce.StatusCode.ToString(),
					Message = ce.Message
				};
				await RewriteBodyAsync(httpContext.Response, responseVM);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				var responseVM = new ResponseViewModel
				{
					Code = HttpStatusCode.InternalServerError.ToString(),
					Message = ex.Message,
					Details = _env.IsDevelopment() ? ex.InnerException.ToString() : null
				};
			}
		}
		private async Task RewriteBodyAsync(HttpResponse httpResponse, ResponseViewModel responseViewModel)
		{
			httpResponse.ContentType = "application/json; charset=utf-8";
			httpResponse.StatusCode = (int)HttpStatusCode.OK;

			await httpResponse.WriteAsJsonAsync(responseViewModel);
		}
	}
}
