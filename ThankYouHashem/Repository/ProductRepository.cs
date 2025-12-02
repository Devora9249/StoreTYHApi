using AutoMapper;
using BooksApi.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;

namespace ThankYouHashem.Repository
{
    public class ProductRepository: IProductRepository

    {
        StoreContext context = LibraryContextFactory.CreateContext();
        private readonly IMapper _mapper;




        //dto
        public List<ProductDto> GetProductsDto()
        {
            return context.Products
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

        

        //procdures
        //1
        public int GetNonDeletedCount()
        {
            var outputParam = new SqlParameter("@count", System.Data.SqlDbType.Int);
            outputParam.Direction = System.Data.ParameterDirection.Output;

            context.Database.ExecuteSqlInterpolated(
                $"EXEC returnIsDeletedNum1 @count={outputParam} OUTPUT"
            );

            return (int)outputParam.Value;
        }

        //2
        //create product by procedure
        public int CreateProductByProc(ProductDto productDto )
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

            context.Database.ExecuteSqlRaw(
            "EXEC AddProducts @name, @price,@categoryName, @NewProductId OUTPUT",
            parameters);
            int newProductId = (int)outputParam.Value;
            return newProductId;
        }

        //mapper
        public List<ProductDto> GetProductsWithMap()
        {
            var products = context.Products
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .ToList();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public Product CreateProduct(CreateProductDto dto)
        {
            var newProduct = new Product
            {
                name = dto.Name,
                price = dto.Price,
                CategoryId = dto.CategoryId,
                description = ""
            };

            context.Products.Add(newProduct);
            context.SaveChanges();
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

            context.Products.AddRange(newProducts);
            context.SaveChanges();
            return newProducts;
        }

        public dynamic GetProductWithCategories()
        {
            var prodCat = context.Categories
                   .Include(x => x.Products)
                    .Select(c => new
                    {
                        c.Name,
                        Products = c.Products.Where(p => !p.IsDeleted).Select(b => b.name)
                    }).ToList();


            return prodCat;

        }

        public dynamic GetProductsSort()
        {
            var products = context.Products.Where(p => !p.IsDeleted)
                .Select(p => p).OrderBy(x => x.name).ToList();
             return products;
        }

        public dynamic getFullOrders()
        {
            var orders = context.Orders.Include(x => x.Products).Select(c => new
            {
                c.Id,
                Products = c.Products.Select(b => b.name)
            }).ToList();
            return orders;
        }

        public Product CreateProduct(Product product)
        {

            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return context.Products
                .Where(p => p.CategoryId == categoryId && !p.IsDeleted)
                .Include(p => p.Category)
                .ToList();
        }

        public List<Product> CreateMultipleProducts(List<Product> products)
        {
            context.Products.AddRange(products);
            context.SaveChanges(); 
            return products;
        }

    }
}
