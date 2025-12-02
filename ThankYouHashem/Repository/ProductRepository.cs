using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;

namespace ThankYouHashem.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // =====================
        // DTO
        // =====================
        public List<ProductDto> GetProductsDto()
        {
            return _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.name,
                    Price = p.price,
                    CategoryName = p.Category.Name
                })
                .ToList();
        }

        // =====================
        // PROCEDURES
        // =====================
        public int GetNonDeletedCount()
        {
            var outputParam = new SqlParameter("@count", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            _context.Database.ExecuteSqlInterpolated(
                $"EXEC returnIsDeletedNum1 @count={outputParam} OUTPUT"
            );

            return (int)outputParam.Value;
        }

        public int CreateProductByProc(ProductDto productDto)
        {
            var outputParam = new SqlParameter
            {
                ParameterName = "@NewProductId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var parameters = new[]
            {
                new SqlParameter("@name", productDto.Name),
                new SqlParameter("@price", productDto.Price),
                new SqlParameter("@categoryName", productDto.CategoryName),
                outputParam
            };

            _context.Database.ExecuteSqlRaw(
                "EXEC AddProducts @name, @price, @categoryName, @NewProductId OUTPUT",
                parameters
            );

            return (int)outputParam.Value;
        }

        // =====================
        // MAPPER
        // =====================
        public List<ProductDto> GetProductsWithMap()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .ToList();

            return _mapper.Map<List<ProductDto>>(products);
        }

        // =====================
        // CRUD
        // =====================
        public Product CreateProduct(CreateProductDto dto)
        {
            var newProduct = new Product
            {
                name = dto.Name,
                price = dto.Price,
                CategoryId = dto.CategoryId,
                description = ""
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public List<Product> CreateMultipleProducts(List<CreateProductDto> products)
        {
            var newProducts = products.Select(p => new Product
            {
                name = p.Name,
                price = p.Price,
                CategoryId = p.CategoryId,
                description = ""
            }).ToList();

            _context.Products.AddRange(newProducts);
            _context.SaveChanges();
            return newProducts;
        }

        public dynamic GetProductWithCategories()
        {
            return _context.Categories
                .Include(x => x.Products)
                .Select(c => new
                {
                    c.Name,
                    Products = c.Products
                        .Where(p => !p.IsDeleted)
                        .Select(b => b.name)
                })
                .ToList();
        }

        public dynamic GetProductsSort()
        {
            return _context.Products
                .Where(p => !p.IsDeleted)
                .OrderBy(x => x.name)
                .ToList();
        }

        public dynamic getFullOrders()
        {
            return _context.Orders
                .Include(x => x.Products)
                .Select(c => new
                {
                    c.Id,
                    Products = c.Products.Select(b => b.name)
                })
                .ToList();
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId && !p.IsDeleted)
                .Include(p => p.Category)
                .ToList();
        }

        public List<Product> CreateMultipleProducts(List<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
            return products;
        }
    }
}
