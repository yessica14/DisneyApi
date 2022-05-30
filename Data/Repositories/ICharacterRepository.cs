using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacterList();
        void SaveCharacter(Character character);
        Character getCharacterById(int Id);
        Character getCharacterByName(string Name);
        List<Character> getCharacterByAge(int Age);
        void UpdateCharacter(Character character);
        void RemoveCharacter(int Id);
        List<Character> GetCharacterToListCharacter(List<Character> characters);
        List<Character> GetCharacterToListCharacter(List<int> characters);

    }
}
