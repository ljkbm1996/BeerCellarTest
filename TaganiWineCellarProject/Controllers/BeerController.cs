using System;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaganiWineCellarProject.Controllers
{
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService beerService;

        public BeerController(IBeerService beerService)
        {
            this.beerService = beerService;
        }

        [HttpGet]
        [Route("api/beer")]
        public async Task<IActionResult> GetBeersAsync()
        {
            try
            {
                var result = await this.beerService.GetBeers();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("api/beers-by-page")]
        public async Task<IActionResult> GetBeersByPageAsync([FromQuery]string page)
        {
            try
            {
                var result = await this.beerService.GetBeersByPageAsync(page);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}