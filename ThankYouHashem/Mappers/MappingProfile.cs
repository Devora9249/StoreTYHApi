namespace ThankYouHashem.Mappers
{
    using AutoMapper;
    using ThankYouHashem.Models;
    using ThankYouHashem.Dto;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,
                 opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryDto>();
        }
    }

}
