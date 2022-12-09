using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRPC_Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductGrpc.Data;
using ProductGrpc.Models;
using ProductGrpc.Protos;
using System.Data;
using System.Data.SqlClient;

namespace ProductGrpc.Services
{
    public class ProductService:ProductProtoService.ProductProtoServiceBase
    {
        private readonly NorthwindDbContext _context;
        private readonly SqlHelper _sqlHelper;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(ILogger<ProductService> logger, 
            NorthwindDbContext context, 
            IMapper mapper,
            SqlHelper sqlHelper
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sqlHelper = sqlHelper ?? throw new Exception(nameof(sqlHelper));
            _context = context ?? throw new ArgumentNullException(nameof(_context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper)); ;
        }
        #region Test
        public override Task<Empty> Test(Empty request, ServerCallContext context)
        {
            return base.Test(request, context);
        }
        #endregion
        #region GetProduct
        public override async Task<ProductModel> GetProduct(GetProductRequest request, 
            ServerCallContext context)
        {
            //SqlHelper.SqlBaglantisiniGetir();
            //SqlDataReader reader = _sqlHelper.ExecuteQueryWithParameters(SqlHelper.Baglanti, "SELECT * FROM Products WHERE productId=@productId", CommandType.Text, new Dictionary<string, object>()
            //{
            //    {"productId",request.ProductId }
            //});

             Product product = await _context.Products.FindAsync(request.ProductId);
            if(product == null)
            {
                //throw an rpc exception
                throw new RpcException(new Status(StatusCode.NotFound,$"Product with ID={request.ProductId} not found"));

			}
            //var productModel = new ProductModel
            //{
            //    ProductId = product.ProductId,
            //    ProductName = product.ProductName,
            //    QuantityPerUnit = product.QuantityPerUnit,
            //    UnitPrice = (long)product.UnitPrice
            //};
            //Mapping from Product to ProductModel
            var productModel = _mapper.Map<ProductModel>(product);
            return productModel;
        }
        #endregion
        #region GetAllproducts
        public override async Task GetAllProducts(GetAllProductsRequest request, 
            IServerStreamWriter<ProductModel> responseStream, 
            ServerCallContext context)
        {
            List<Product> products = await _context.Products.ToListAsync();


            if (products.Count == 0)
            {
				//throw an rpc exception
				throw new RpcException(new Status(StatusCode.NotFound, $"Products not found"));
			}

            foreach (var product in products)
            {
                var productModel = _mapper.Map<ProductModel>(product);
                await responseStream.WriteAsync(productModel);
            }

        }
        #endregion
        #region AddProduct
        public override async Task<ProductModel> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            var product = _mapper.Map<Product>(request.Product);
            //Product product = new Product()
            //{
            //    ProductId = request.Product.ProductId,
            //    ProductName = request.Product.ProductName,
            //    QuantityPerUnit = request.Product.QuantityPerUnit,
            //    UnitPrice = request.Product.UnitPrice
            //};
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return request.Product;
        }
        #endregion
        #region DeleteProduct
        public override async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
				//throw an rpc exception
				throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID={request.ProductId} not found"));
			}
            _context.Products.Remove(product);
            var deletedCount = 0;
            try
            {
                deletedCount = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            var response = new DeleteProductResponse()
            {
                IsSuccess = deletedCount > 0 ? true : false,
            };
            return response;
        }
        #endregion
        #region UpdateProduct
        public override async Task<ProductModel> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            var product = _mapper.Map<Product>(request.Product);

            bool isExist = await _context.Products.AnyAsync(p => p.ProductId == product.ProductId);
            if(!isExist)
            {
				//throw a rpc exception
				throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID={product.ProductId} not found"));
			}
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return request.Product;
           
        }
		#endregion
		#region InsertBulkProduct
		public override async Task<InsertBulkProductResponse> InsertBulkProduct(IAsyncStreamReader<ProductModel> requestStream, ServerCallContext context)
		{
            while (await requestStream.MoveNext())
            {
                var product = _mapper.Map<Product>(requestStream.Current);
                _context.Products.Add(product);
            }
            var insertCount = await _context.SaveChangesAsync();

            var response = new InsertBulkProductResponse
            {
                IsSuccess = insertCount > 0,
                InsertCount = insertCount,
            };

            return response;
		}
		#endregion

	}
}
