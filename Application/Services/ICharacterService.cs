using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public interface ICharacterService
    {
        List<ListCharacterDTO> getCharacter();

        List<CharacterDTO> getCharacterCRUD();
        bool SaveCharacter(Character character);

        bool UpdateCharacter(int Id, CharacterDTO character);

        bool RemoveCharacter(int Id);

        CharacterDTO GetCharacterByName(string Name);

        CharacterDTO GetCharacterByAge(int Age);
    }
}
