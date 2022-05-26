using Alkemy.Disney.Api.Application.Services;
using Alkemy.Disney.Api.Data.Context;
using Alkemy.Disney.Api.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Controller
{
   [ApiController]
    public class ProductionController : ControllerBase
    {
        private IProductionService _productionService;

        public ProductionController(MVCContext context, IConfiguration config, IProductionService productionService)
        {
            _productionService = productionService;
        }

        [HttpGet("movies")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var productions = _productionService.GetMovieDtoList();
            return Ok(productions);
        }
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Post(Production production)
        //{
        //    //var newProduction = new Production();
        //    //newProduction.Id = production.Id;
        //    //newProduction.Image = production.Image
        //    _productionService.CreateProduction(production);

        //    var productions = _productionService.GetMovieDtoList();
        //    return Ok(productions);
        //}


        [HttpGet("movies/{Name}")]
        [Authorize]

        public async Task<IActionResult> Get(string Name)
        {
            var productions = _productionService.GetMovieByTitle(Name);
            if (productions == null)
            {
                return NotFound();
            }
            else
                return Ok(productions);
        }

        [HttpGet("{genre}")]
        [Authorize]

        public async Task<IActionResult> GetGenero(string genre)
        {
            var production = _productionService.GetMovieByGender(genre);
            return Ok(production);
        }

    }
}
