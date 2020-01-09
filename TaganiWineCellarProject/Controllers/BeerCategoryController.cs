using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaganiWineCellarProject.Controllers
{
    [Route("api/beer-category")]
    [ApiController]
    public class BeerCategoryController : ControllerBase
    {
        private readonly IBeerCategoryService beerCategoryService;

        public BeerCategoryController(IBeerCategoryService beerCategoryService)
        {
            this.beerCategoryService = beerCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBeerCategoryAsync()
        {
            try
            {
                var result = await this.beerCategoryService.GetBeerCategoryAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
