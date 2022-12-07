using System;
using Grpc.Core;
using Grpc.Net.Client;
using gRPC_Helper;
using gRPC_Helper.Extensions;
using ProductGrpc.Models;
using ProductGrpc.Protos;

Console.WriteLine("Waiting for server is running...");
Thread.Sleep(2000);

using var channel = GrpcChannel.ForAddress("http://localhost:5181");
var client = new ProductProtoService.ProductProtoServiceClient(channel);

//await GetProductAsync(client);
//await GetAllProductsAsync(client);
//await AddProductAsync(client);
//await DeleteProductAsync(client);
//await UpdateProduct(client);

#region GetProductAsync
async static Task GetProductAsync(ProductProtoService.ProductProtoServiceClient client)
{
    //GetProductAsync
    Console.WriteLine("GetProductAsync started...");

    var singleProduct = await client.GetProductAsync(

        new GetProductRequest
        {
            ProductId = 3,
        });
    Console.WriteLine($"GetProductAsync Response ==> {singleProduct}");

    Console.WriteLine("GetProductAsync ended...");
}
#endregion

#region GetAllProductsAsync
async static Task GetAllProductsAsync(ProductProtoService.ProductProtoServiceClient client)
{
    //GetAllProducts
    Console.WriteLine("GetAllProductsAsync started...");

    Thread.Sleep(2000);

    //var AllProducts = client.GetAllProducts(new GetAllProductsRequest());

    //while(await AllProducts.ResponseStream.MoveNext(new CancellationTokenSource().Token))
    //{
    //    var currentProduct = AllProducts.ResponseStream.Current;
    //    Console.WriteLine(currentProduct);
    //    Thread.Sleep(1000);
    //}

    //Console.WriteLine("GetAllProductsAsync ended...");


    //GetAllProducts with c#9.0

    using var clientData = client.GetAllProducts(new GetAllProductsRequest());
    await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine(responseData);
    }
    Console.WriteLine("GetAllProductsAsync ended...");
}
#endregion

#region AddProductAsync
static async Task AddProductAsync(ProductProtoService.ProductProtoServiceClient client)
{
    //AddProductAsync
    Console.WriteLine("AddProductAsync started...");
    Thread.Sleep(2000);
    //Product product = new Product()
    //{
    //    ProductName = "Test",
    //    QuantityPerUnit = "65656",
    //    UnitPrice = 656
    //};
    var clientData = await client.AddProductAsync(new AddProductRequest
    {
        Product = new ProductModel
        {
            ProductName = "Test",
            QuantityPerUnit = "65656",
            UnitPrice = 656
        }
    });
    await global::System.Console.Out.WriteLineAsync($"Response ==> {clientData}");
}
#endregion

#region DeleteProduct
static async Task DeleteProductAsync(ProductProtoService.ProductProtoServiceClient client)
{
    //DeleteProduct
    await global::System.Console.Out.WriteLineAsync("DeleteProduct started...");



    var clientResponse = client.DeleteProduct(new DeleteProductRequest()
    {
        ProductId = 4
    });
    await global::System.Console.Out.WriteLineAsync($"Başarılı mı? {clientResponse.IsSuccess.ToString()}");
    await global::System.Console.Out.WriteLineAsync("DeleteProduct ended...");
}
#endregion

#region UpdateProduct
async Task UpdateProduct(ProductProtoService.ProductProtoServiceClient client)
{
    //UpdateProduct
    await global::System.Console.Out.WriteLineAsync("UpdateProduct started...");
    var productModel = new ProductModel()
    {
        ProductId = 5, ProductName = "Test",
        QuantityPerUnit = "asdasdasd",
        UnitPrice = 123123
    };
    var responseData = await client.UpdateProductAsync(new UpdateProductRequest()
    {
        Product = productModel
    });
    await global::System.Console.Out.WriteLineAsync(responseData.ToString());
    await global::System.Console.Out.WriteLineAsync("UpdateProduct ended...");
}
#endregion