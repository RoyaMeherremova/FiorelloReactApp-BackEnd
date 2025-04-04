using Service.DTOs;
using Service.DTOs.Category;
using Service.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
       

        Task<CategoryDto> GetByIdAsync(int? id);
        Task DeleteAsync(int? id);
        Task<IEnumerable<CategoryDto>> SearchAsync(string? searchText);
    }
}
