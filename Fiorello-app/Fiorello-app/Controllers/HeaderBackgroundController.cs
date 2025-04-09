using Microsoft.AspNetCore.Mvc;
using Service.DTOs.HeaderBackgroundDto;
using Service.Services.Interfaces;

namespace Fiorello_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HeaderBackgroundController : Controller
    {
        private readonly IHeaderBackgroundService _service;

        public HeaderBackgroundController(IHeaderBackgroundService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<HeaderBackgroundDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}

