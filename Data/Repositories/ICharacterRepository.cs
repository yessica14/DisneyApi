using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacter();

        void SaveCharacter(Character character);

        void UpdateCharacter(Character character);
        void RemoveCharacter(int Id);
    }
}
