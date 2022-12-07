using gRPC_Helper;
using Microsoft.EntityFrameworkCore;
using ProductGrpc.Data;
using ProductGrpc.Mapper;
using ProductGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<SqlHelper>();
builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-OKIVNDG;Initial Catalog=Northwind;User ID=onur;Password=12345onur;Encrypt=False;MultipleActiveResultSets=True;TrustServerCertificate=False;");
});
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new ProductProfile());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
