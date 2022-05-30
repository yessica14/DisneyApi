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
        public List<Character> GetCharacterList()
        {
            var personages = _context.Character.ToList();
            return personages;
        }

        public void SaveCharacter(Character character)
        {
            _context.Character.Add(character);
            _context.SaveChanges();
        }
        public Character getCharacterById(int Id)
        {
            var character = _context.Character.Where(x => x.Id == Id).FirstOrDefault();
            return character;
        }
        public Character getCharacterByName(string Name)
        {
            var character = _context.Character.Where(x => x.Name == Name).FirstOrDefault();
            return character;
        }
        public List<Character> getCharacterByAge(int Age)
        {
            var characters = _context.Character.Where(x => x.Age == Age).ToList();
            return characters;
        }

        public List<Character> GetCharacterByIdMovie(int Id)
        {
            var production = _context.Production
                .Include(x => x.Characters)
                .Where(x => x.Id == Id)
                .FirstOrDefault();
            if (production == null)
                return null;

            return production.Characters.ToList();
            /*
            var characters = _context.Character
                .Include(x => x.Productions)
                .ToList();

            var listcharacter = new List<Character>();

            foreach(var character in characters)
            {
                foreach(var production in character.Productions)
                {
                    if(production.Id == Id)
                    {
                        listcharacter.Add(character);
                    }
                }
            }

            return listcharacter;
            */
        }

        public void UpdateCharacter(Character character)
        {
            try
            {
                _context.Character.Attach(character);
                _context.Entry(character).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            //_context.Character.Update(character);
            
        }

        public void RemoveCharacter(int Id)
        {
            var character = _context.Character.Where(x => x.Id == Id).FirstOrDefault();

            _context.Character.Remove(character);
            _context.SaveChanges();
        }
        
        public List<Character> GetCharacterToListCharacter(List<Character> characters)
        {
            var newlistCharacter = new List<Character>();
            var listcharacter = _context.Character.ToList();
            
            foreach(var character in characters)
            {
                var characterAsign = listcharacter.Where(x => x.Id == character.Id).FirstOrDefault();
                newlistCharacter.Add(characterAsign);
            }
            return newlistCharacter;
        }

        public List<Character> GetCharacterToListCharacter(List<int> characters)
        {
            var newlistCharacter = new List<Character>();
            var listcharacter = _context.Character.ToList();

            foreach (var character in characters)
            {
                var characterAsign = listcharacter.Where(x => x.Id == character).FirstOrDefault();
                newlistCharacter.Add(characterAsign);
            }
            return newlistCharacter;
        }

    }
}
