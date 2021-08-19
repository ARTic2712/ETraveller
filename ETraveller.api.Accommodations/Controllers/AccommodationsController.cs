using ETraveller.api.Accommodations.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ETraveller.api.Accommodations.Controllers
{
    [Route("api/accommodations")]
    [ApiController]
    public class AccommodationsController : ControllerBase
    {
        private readonly IAccommodationProvider _accommodationProvider;
        public AccommodationsController(IAccommodationProvider accommodationProvider)
        {
            _accommodationProvider = accommodationProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            var result = await _accommodationProvider.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetTaskAsync(Guid id)
        {
            var result = await _accommodationProvider.GetAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
