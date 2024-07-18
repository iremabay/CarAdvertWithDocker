using CarAdverts.Models;
using CarAdverts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAdverts.Controllers
{
    [Route("api/[controller]")]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertRepository _advertRepository;
        public AdvertsController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAdverts([FromQuery] int categoryId, [FromQuery] decimal? price, [FromQuery] string gear, [FromQuery] string fuel, [FromQuery] int page = 1, [FromQuery] string sortBy = "price")
        {
            var adverts = await _advertRepository.GetAdvertsAsync(categoryId, price, gear, fuel, page, sortBy);
            if (adverts == null)
            {
                return NoContent();
            }
           
            var response = new
            {
                total = adverts.Count(),
                page,
                adverts
            };
            return Ok(response);
        }
    }
}
