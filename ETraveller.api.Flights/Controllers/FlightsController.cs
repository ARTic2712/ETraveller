using ETraveller.api.Flights.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ETraveller.api.Flights.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightProvider _flightProvider;

        public FlightsController(IFlightProvider flightProvider)
        {
            _flightProvider = flightProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            var result = await _flightProvider.GetAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetTaskAsync(Guid id)
        {
            var result = await _flightProvider.GetAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }

        [HttpGet, Route("travel/{travelId}")]
        public async Task<IActionResult> GetFlightByTravelAsync(Guid travelId)
        {
            var result = await _flightProvider.GetAsync(w => w.TravelId == travelId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
