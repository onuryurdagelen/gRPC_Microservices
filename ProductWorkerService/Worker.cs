using System;
using Grpc.Net.Client;
using ProductGrpc.Protos;

namespace ProductWorkerService
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly IConfiguration _configuration;

		public Worker(ILogger<Worker> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
            await Console.Out.WriteLineAsync("Stopping Token: "+stoppingToken.IsCancellationRequested.ToString());
            while (!stoppingToken.IsCancellationRequested)
			{
				await Console.Out.WriteLineAsync("Stopping Token: " + stoppingToken.IsCancellationRequested.ToString());
				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

				using var channel = GrpcChannel.ForAddress(_configuration.GetValue<string>("WorkerService:ServerUrl"));
				var client = new ProductProtoService.ProductProtoServiceClient(channel);
                await global::System.Console.Out.WriteLineAsync("GetProductsAsync starter...");
				var response = await client.GetProductAsync(new GetProductRequest
				{
					ProductId = 21
				});
                await global::System.Console.Out.WriteLineAsync($"GetProductAsync Response =>{response.ToString()}");

                await Task.Delay(_configuration.GetValue<int>("WorkerService:TaskInterval"), stoppingToken);
			}
		}
	}
}