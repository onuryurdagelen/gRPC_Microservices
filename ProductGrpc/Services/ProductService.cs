using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductGrpc.Data;
using ProductGrpc.Models;
using ProductGrpc.Protos;

namespace ProductGrpc.Services
{
    public class ProductService:ProductProtoService.ProductProtoServiceBase
    {
        private readonly NorthwindDbContext _context;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(ILogger<ProductService> logger, NorthwindDbContext context, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            Product product = await _context.Products.FindAsync(request.ProductId);
            if(product == null)
            {
                //throw an rpc exception
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
            List<Product> products = await _context.Products.ToListAsync(context.CancellationToken);
            if(products .Count == 0)
            {
                //throw an rpc exception
            }

            foreach(var product in products) 
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

    }
}
