using ETraveller.api.Travels.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ETraveller.api.Travels.Controllers
{
    [ApiController]
    [Route("api/travels")]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelProvider _travelProvider;

        public TravelsController(ITravelProvider travelProvider)
        {
            _travelProvider = travelProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetTravelsAsync()
        {
            var result = await _travelProvider.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetTravelAsync(Guid id)
        {
            var result = await _travelProvider.GetAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
        [HttpGet, Route("{id}/flights")]
        public async Task<IActionResult> GetTravelFlightsAsync(Guid id)
        {
            var result = await _travelProvider.GetTravelFlightsAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
