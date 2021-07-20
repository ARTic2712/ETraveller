using ETraveller.api.Travels.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetTaskAsync()
        {
            var result = await _travelProvider.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}
