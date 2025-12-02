

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ThankYouHashem.Dto;

namespace ThankYouHashem.Models
{
    public interface IProductService
    {
        //dto
    public List<ProductDto> GetOrdersDto();

    public Product CreateProduct(CreateProductDto dto);

    public List<Product> CreateMultiple(List<CreateProductDto> dtos);

    //output
    public int GetActiveProductsCount();

    //transaction create prod
    public int CreateProductByProc(ProductDto dto);
    public List<ProductDto> GetProductsWithMap();

    public dynamic GetProductWithCategories();

    public dynamic GetProductsSort();

    public Product CreateProduct(Product product);

    public dynamic getFullOrders();

    public dynamic GetProductsByCategory(int categoryId);

    public dynamic CreateMultipleProducts(List<Product> products);
}
}

