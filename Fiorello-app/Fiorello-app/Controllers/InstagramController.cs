using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Instagram;
using Service.DTOs.Slider;
using Service.Services.Interfaces;

namespace Fiorello_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstagramController : Controller
    {
        private readonly IInstagramService _service;

        public InstagramController(IInstagramService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<InstagramDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
