using Microsoft.AspNetCore.Mvc;
using Service.DTOs.SectionBackgroundImage;
using Service.DTOs.Slider;
using Service.Services.Interfaces;

namespace Fiorello_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectionBackgroundController : Controller
    {
        private readonly ISectionBackgroundService _service;

        public SectionBackgroundController(ISectionBackgroundService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<SectionBackgroundDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
