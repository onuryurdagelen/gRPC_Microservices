using Grpc.Core;
using Grpc.Net.Client;
using ProductGrpc.Models;
using ProductGrpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace gRPC_WFormUI.Service
{
    public class ProductService
    {
        private static GrpcChannel Channel { get; set; }
        public Product oProduct { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        private static ProductProtoService.ProductProtoServiceClient Client { get; set; }
        public ProductService()
        {
            Channel = GrpcChannel.ForAddress("http://localhost:5181");
            Client = new ProductProtoService.ProductProtoServiceClient(Channel);
        }

        #region GetProductAsync
        public async Task<Product> GetProductAsync(int productId)
        {
            //GetProductAsync
            Console.WriteLine("GetProductAsync started...");

            var singleProduct = await Client.GetProductAsync(

                new GetProductRequest
                {
                    ProductId = productId,
                });
            oProduct = new Product()
            {
                ProductId = singleProduct.ProductId,
                ProductName = singleProduct.ProductName,
                UnitPrice = singleProduct.UnitPrice,
                QuantityPerUnit = singleProduct.QuantityPerUnit,
            };
          
            Console.WriteLine($"GetProductAsync Response ==> {singleProduct}");

            Console.WriteLine("GetProductAsync ended...");

            return oProduct;
        }
        #endregion

        #region GetAllProductsAsync
        public async Task<List<Product>> GetAllProductsAsync()
        {
            //GetAllProducts
            Console.WriteLine("GetAllProductsAsync started...");

            //var AllProducts = client.GetAllProducts(new GetAllProductsRequest());

            //while(await AllProducts.ResponseStream.MoveNext(new CancellationTokenSource().Token))
            //{
            //    var currentProduct = AllProducts.ResponseStream.Current;
            //    Console.WriteLine(currentProduct);
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("GetAllProductsAsync ended...");


            //GetAllProducts with c#9.0

            try
            {
                var clientData = Client.GetAllProducts(new GetAllProductsRequest());
                await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
                {
                    Products.Add(new Product()
                    {
                        ProductId = responseData.ProductId,
                        ProductName = responseData.ProductName,
                        QuantityPerUnit = responseData.QuantityPerUnit,
                        UnitPrice = responseData.UnitPrice,
                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
            Console.WriteLine("GetAllProductsAsync ended...");
            return Products;
        }
        #endregion
    }
}
