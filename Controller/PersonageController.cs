using Alkemy.Disney.Api.Application.Services;
using Alkemy.Disney.Api.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Controller
{
    [ApiController]
    public class PersonageController : ControllerBase
    {
        private IPersonageService _personageService;
        public PersonageController(IPersonageService personageService)
        {
            _personageService = personageService;
        }
        [HttpGet("character")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var personages = _personageService.getPersonage();
            return Ok(personages);
        }

        [HttpPost("PersonagePost")]
        [Authorize]
        public async Task<IActionResult> Post(Personage personage)
        {
            var persongeExist = _personageService.SavePersonage(personage);
            if (persongeExist)
                return NotFound();
            return Ok(persongeExist);
        }

        [HttpDelete("character/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var personajeExist = _personageService.RemovePersonage(Id);
            if (personajeExist)
                return NotFound();
            return Ok(personajeExist);
        }

        [HttpGet("charactern/{Name}")]
        [Authorize]
        public async Task<IActionResult> GetCharacterByName(string Name)
        {
            var chara = _personageService.GetPersonageByName(Name);
            if (chara == null)
                return NotFound();
            return Ok(chara);
        }

        [HttpGet("character/{Age}")]
        [Authorize]
        public async Task<IActionResult> GetCharacterByAge(int Age)
        {
            var character = _personageService.GetPersonageByAge(Age);
            if (character == null)
                return NotFound();
            return Ok(character);
        }
    }
}
