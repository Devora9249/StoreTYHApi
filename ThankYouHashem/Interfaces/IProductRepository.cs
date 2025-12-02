

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ThankYouHashem.Dto;

namespace ThankYouHashem.Models
{
    public interface IProductRepository
    {
        public List<ProductDto> GetProductsDto();

        //procdures
        //1
        public int GetNonDeletedCount();

        //2
        //create product by procedure
        public int CreateProductByProc(ProductDto productDto);

        //mapper
        public List<ProductDto> GetProductsWithMap();

        public Product CreateProduct(CreateProductDto dto);

        public List<Product> CreateMultipleProducts(List<CreateProductDto> products);
        
        public dynamic GetProductWithCategories();

        public dynamic GetProductsSort();

        public dynamic getFullOrders();

        public Product CreateProduct(Product product);

        public List<Product> GetProductsByCategory(int categoryId);

        public List<Product> CreateMultipleProducts(List<Product> products);

    }
}
