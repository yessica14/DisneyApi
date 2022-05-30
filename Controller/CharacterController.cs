using Alkemy.Disney.Api.Application.Dto;
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
    public class CharacterController : ControllerBase
    {
        private ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpGet("character")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var characters = _characterService.getCharacter();
            return Ok(characters);
        }

        [HttpPost("CharacterPost")]
        [Authorize]
        public async Task<IActionResult> Post(CharacterDTO characterDTO)
        {
            var operation = _characterService.SaveCharacter(characterDTO);
            return Ok(operation);
        }

        [HttpPut("characterPut/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCharacter(int id, CharacterDTO characterDTO)
        {
            var operation = _characterService.UpdateCharacter(id, characterDTO);
            return Ok(operation);
        }

        [HttpDelete("character/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var operation = _characterService.RemoveCharacter(Id);
            return Ok(operation);
        }

        [HttpGet("charactern/{Name}")]
        [Authorize]
        public async Task<IActionResult> GetCharacterByName(string Name)
        {
            var character = _characterService.GetCharacterByName(Name.ToUpper());
            if (character == null)
                return NotFound();
            return Ok(character);
        }

        [HttpGet("character/{Age}")]
        [Authorize]
        public async Task<IActionResult> GetCharacterByAge(int Age)
        {
            var characters = _characterService.GetCharacterByAge(Age);
            if (characters == null)
                return NotFound();
            return Ok(characters);
        }
    }
}
