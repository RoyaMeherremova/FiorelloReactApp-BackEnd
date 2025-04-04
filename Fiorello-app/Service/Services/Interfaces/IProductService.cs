using Domain.Models;
using Service.DTOs.Product;
using Service.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> SortProductsAsync(string sort);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(int categorId);
        Task<IEnumerable<ProductDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}
