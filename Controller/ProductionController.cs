using Alkemy.Disney.Api.Application.Dto;
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

        [HttpGet("GetProduccionById")]
        [Authorize]
        public async Task<IActionResult> GetProduccionById(int Id)
        {
            var production = _productionService.GetDetailProductionById(Id);
            return Ok(production);
        }

        [HttpPost("MoviePost")]
        [Authorize]
        public async Task<IActionResult> PostMovie(ProductionPostDTO production)
        {
            var operation = _productionService.SaveProduction(production);
            return Ok(operation);
        }

        [HttpPut("productionPut/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduction(int id, ProductionUpdateDTO productionDTO)
        {
            var operation = _productionService.UpdateProduction(id, productionDTO);
            return Ok(operation);
        }

        [HttpDelete("production/{Id}")]
        [Authorize]
        public async Task<IActionResult> ProductionDelete(int Id)
        {
            var operation = _productionService.RemoveProduction(Id);
            return Ok(operation);
        }

        [HttpGet("movies/{Name}")]
        [Authorize]

        public async Task<IActionResult> Get(string Name)
        {
            var production = _productionService.GetMovieByTitle(Name.ToUpper());
            if (production == null)
            {
                return NotFound();
            }
            else
                return Ok(production);
        }

        [HttpGet("{genre}")]
        [Authorize]

        public async Task<IActionResult> GetGenero(int genre)
        {
            var production = _productionService.GetMovieByGender(genre);
            if (production == null)
            {
                return NotFound();
            }
            return Ok(production);
        }

    }
}
