using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.DTOs.Product;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync() => _mapper.Map<IEnumerable<ProductDto>>(await _productRepo.GetAllProductsWithCategories());

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepo.GetProductsByCategoryIdAsync(categoryId);

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> SortProductsAsync(string sortOrder)
        {
                var products = await _productRepo.SortProductsAsync(sortOrder);
                return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task<IEnumerable<ProductDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var products = await _productRepo.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }



    }
}
