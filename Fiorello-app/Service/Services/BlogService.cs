using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Blog;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepo;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepo, IMapper mapper)
        {
            _blogRepo = blogRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            var blogs = await _blogRepo.FindBlogWithImagesAsync();

            var blogDtos = blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                CreatedAt = b.CreatedDate,
                Images = b.BlogImages.Select(img => new BlogImageDto
                {
                    Image = img.Image,
                    IsMain = img.IsMain
                }).ToList()
            }).ToList();

            return blogDtos;
        }
    }
}
