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
        public async Task<IActionResult> Post(Character character)
        {
            var characterExist = _characterService.SaveCharacter(character);
            if (characterExist)
                return NotFound();
            return Ok(characterExist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonage(int id, CharacterDTO character)
        {
            var characterExist = _characterService.UpdateCharacter(id, character);
            if (!characterExist)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("character/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var characterExist = _characterService.RemoveCharacter(Id);
            if (characterExist)
                return NotFound();
            return Ok(characterExist);
        }

        [HttpGet("charactern/{Name}")]
        [Authorize]
        public async Task<IActionResult> GetCharacterByName(string Name)
        {
            var chara = _characterService.GetCharacterByName(Name);
            if (chara == null)
                return NotFound();
            return Ok(chara);
        }

        [HttpGet("character/{Age}")]
        [Authorize]
        public async Task<IActionResult> GetCharacterByAge(int Age)
        {
            var character = _characterService.GetCharacterByAge(Age);
            if (character == null)
                return NotFound();
            return Ok(character);
        }
    }
}
