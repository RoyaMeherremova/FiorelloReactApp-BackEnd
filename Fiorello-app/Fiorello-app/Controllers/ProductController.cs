using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Service.DTOs.Product;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fiorello_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase  
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
       
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryByProduct([FromRoute] int id)
        {
            try
            {
                var products = await _service.GetProductsByCategoryIdAsync(id);

                if (products == null || !products.Any())
                {
                    return NotFound($"Продукты для категории с id {id} не найдены.");
                }

                return Ok(products);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка на сервере: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SortProducts([FromQuery] string sort)
        {
            try
            {
                if (string.IsNullOrEmpty(sort) || (sort.ToLower() != "low-to-high" && sort.ToLower() != "high-to-low"))
                {
                    return BadRequest("Неверный параметр сортировки. Используйте 'low-to-high' или 'high-to-low'.");
                }

                var products = await _service.SortProductsAsync(sort.ToLower());

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка на сервере: {ex.Message}");
            }
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductsByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            try
            {
                if (minPrice <= 0 || maxPrice <= 0)
                {
                    return BadRequest("Цены должны быть больше нуля.");
                }

                var products = await _service.GetProductsByPriceRangeAsync(minPrice, maxPrice);

                if (products == null || !products.Any())
                {
                    return NotFound($"Продукты не найдены в диапазоне цен от {minPrice} до {maxPrice}.");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка на сервере: {ex.Message}");
            }
        }
    }
}


