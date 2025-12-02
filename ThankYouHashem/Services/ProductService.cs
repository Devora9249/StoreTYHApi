using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThankYouHashem.Dto;
using ThankYouHashem.Models;
using ThankYouHashem.Repository;

namespace ThankYouHashem.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repo)
        {
            _repository = repo;
        }

        //dto
        public List<ProductDto> GetOrdersDto()

        {
            return _repository.GetProductsDto();
        }

        public Product CreateProduct(CreateProductDto dto)
        {
            return _repository.CreateProduct(dto);
        }

        public List<Product> CreateMultiple(List<CreateProductDto> dtos)
        {
            return _repository.CreateMultipleProducts(dtos);
        }

        //output
        public int GetActiveProductsCount()
        {
            return _repository.GetNonDeletedCount();
        }

        //transaction create prod
        public int CreateProductByProc(ProductDto dto)

        {
            return _repository.CreateProductByProc(dto);

        }
        public List<ProductDto> GetProductsWithMap()
        {
            return _repository.GetProductsWithMap();
        }

        public dynamic GetProductWithCategories()
        {
            return _repository.GetProductWithCategories();
        }

        public dynamic GetProductsSort()
        {
            return _repository.GetProductsSort();
        }

        public Product CreateProduct(Product product)
        {
            return _repository.CreateProduct(product);
        }

        public dynamic getFullOrders()
        {
           return _repository.getFullOrders();
        }

        public dynamic GetProductsByCategory(int categoryId) {
            return _repository.GetProductsByCategory(categoryId);
        }

        public dynamic CreateMultipleProducts(List<Product> products) { 
           return _repository.CreateMultipleProducts(products);
        }
    }
}
