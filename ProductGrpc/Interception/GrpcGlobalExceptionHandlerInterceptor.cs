using Grpc.Core.Interceptors;
using Grpc.Core;
using gRPC_Shared.ViewModels;
using gRPC_Helper.ExceptionHandler;
using System.Net;

namespace ProductGrpc.Interception
{
	public class GrpcGlobalExceptionHandlerInterceptor : Interceptor
	{
		private readonly ILogger<GrpcGlobalExceptionHandlerInterceptor> _logger;
		private readonly IHostEnvironment _env;

		public GrpcGlobalExceptionHandlerInterceptor(ILogger<GrpcGlobalExceptionHandlerInterceptor> logger,
			IHostEnvironment env)
		{
			_logger = logger;
			_env = env;	
		}

		public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
			ServerCallContext context,
			UnaryServerMethod<TRequest, TResponse> continuation)
		{
			try
			{
				return await base.UnaryServerHandler(request, context, continuation);
			}
			catch (CustomException ce)
			{
				var responseVm = new ResponseViewModel
				{
					Code = ce.StatusCode.ToString(),
					Message = ce.Message
				};

				return MapResponse<TRequest, TResponse>(responseVm);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				var responseVm = new ResponseViewModel
				{
					Code = HttpStatusCode.InternalServerError.ToString(),
					Message = "Server error",
					Details = _env.IsDevelopment() ? ex.InnerException.ToString() : null
				};

				return MapResponse<TRequest, TResponse>(responseVm);
			}
		}
		
		private TResponse MapResponse<TRequest, TResponse>(ResponseViewModel responseViewModel)
		{
			var concreteResponse = Activator.CreateInstance<TResponse>();

			concreteResponse?.GetType().GetProperty(nameof(responseViewModel.Code))?.SetValue(concreteResponse, responseViewModel.Code);

			concreteResponse?.GetType().GetProperty(nameof(responseViewModel.Message))?.SetValue(concreteResponse, responseViewModel.Message);

			return concreteResponse;
		}
	}
}
