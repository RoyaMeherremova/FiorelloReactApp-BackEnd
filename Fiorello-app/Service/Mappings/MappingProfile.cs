using AutoMapper;
using Domain.Models;
using Service.DTOs.Blog;
using Service.DTOs.Category;
using Service.DTOs.Expert;
using Service.DTOs.Instagram;
using Service.DTOs.Product;
using Service.DTOs.Say;
using Service.DTOs.Slider;
using Service.DTOs.Video;

namespace Service.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Video, VideoDto>().ReverseMap();
            CreateMap<Expert, ExpertDto>().ReverseMap();
            CreateMap<Blog, BlogDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.BlogImages));
            CreateMap<BlogImage, BlogImageDto>();
            CreateMap<Say, SayDto>();
            CreateMap<Instagram, InstagramDto>();






        }

    }


    
}
