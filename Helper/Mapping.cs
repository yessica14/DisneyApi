using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Helper
{
    public static class Mapping
    {
        public static CharacterDTO ConvertCharacterToDto(Character character)
        {
            var characterDto = new CharacterDTO
            {
                Id = character.Id,
                //Image = character.Image.ToString(),
                Name = character.Name,
                Age = character.Age,
                Weight = character.Weight,
                History = character.History
            };

            return characterDto;
        }

        public static Character ConvertDtoToCharacter(CharacterDTO characterdto)
        {
            var character = new Character
            {
                Id = characterdto.Id,
                //Image = characterdto.Image,
                Name = characterdto.Name,
                Age = characterdto.Age,
                Weight = characterdto.Weight,
                History = characterdto.History
            };

            return character;
        }
    }
}
