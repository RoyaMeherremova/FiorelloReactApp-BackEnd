using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs;
using Service.DTOs.Category;
using Service.DTOs.Product;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _categoryRepo.DeleteAsync(await _categoryRepo.GetByIdAsync(id));


        public async Task<IEnumerable<CategoryDto>> GetAllAsync() => _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepo.FindAllAsync());

        public async Task<CategoryDto> GetByIdAsync(int? id) => _mapper.Map<CategoryDto>(await _categoryRepo.GetByIdAsync(id));
      

        public Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> SearchAsync(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepo.FindAllAsync());
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepo.FindAllAsync(m => m.Name.Contains(searchText)));
        }

       
    }
}
