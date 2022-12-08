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
                UnitPrice = Convert.ToInt32(singleProduct.UnitPrice),
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

            var clientData = Client.GetAllProducts(new GetAllProductsRequest());
            await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
            {
                Products.Add(new Product()
                {
                    ProductId = responseData.ProductId,
                    ProductName = responseData.ProductName,
                    QuantityPerUnit = responseData.QuantityPerUnit,
                    UnitPrice = Convert.ToInt32(responseData.UnitPrice),
                });
            }


            Console.WriteLine("GetAllProductsAsync ended...");
            return Products;
        }
        #endregion

        #region AddProductAsync
        public async Task<ProductModel> AddProductAsync(Product product)
        {
            var productModel = new ProductModel()
            {
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = (long)product.UnitPrice
            };
            var clientData = await Client.AddProductAsync(new AddProductRequest()
            {
                Product = productModel
            });
            return clientData;
        }
        #endregion

        #region UpdateProductAsync
        public async Task<ProductModel> UpdateProduct(Product product)
        {
            var productModel = new ProductModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = Convert.ToInt64(product.UnitPrice)
            };
            var clientData = await Client.UpdateProductAsync(new UpdateProductRequest()
            {
                Product = productModel
            });

            return clientData;
        }
        #endregion
    }
}
