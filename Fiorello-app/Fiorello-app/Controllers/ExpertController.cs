using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Slider;
using Service.Services.Interfaces;

namespace Fiorello_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpertController : Controller
    {
        private readonly IExpertService _service;

        public ExpertController(IExpertService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<SliderDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
