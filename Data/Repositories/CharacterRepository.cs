using Alkemy.Disney.Api.Data.Context;
using Alkemy.Disney.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly MVCContext _context;

        public CharacterRepository(MVCContext context)
        {
            _context = context;
        }
        public List<Character> GetCharacter()
        {
            var personages = _context.Character.ToList();
            return personages;
        }

        public void SaveCharacter(Character character)
        {
            _context.Character.Add(character);
            _context.SaveChanges();
        }

        public void UpdateCharacter(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveCharacter(int Id)
        {
            var character = _context.Character.Where(x => x.Id == Id).FirstOrDefault();

            _context.Character.Remove(character);
            _context.SaveChanges();
        }

    }
}
