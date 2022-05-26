using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private ICharacterRepository _characterRepository;
        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public List<ListCharacterDTO> getCharacter()
        {
            var characters = _characterRepository.GetCharacter();

            var listCharacterDto = new List<ListCharacterDTO>();

            foreach (var character in characters)
            {
                listCharacterDto.Add(new ListCharacterDTO
                {
                    Image = character.Image,
                    Name = character.Name,
                }); ;
            }
            return listCharacterDto;
        }

        public List<CharacterDTO> getCharacterCRUD()
        {
            var personages = _characterRepository.GetCharacter();

            var listCharacterDto = new List<CharacterDTO>();

            foreach (var personage in personages)
            {
                listCharacterDto.Add(new CharacterDTO
                {
                    Id = personage.Id,
                    //Image = personage.Image,
                    Name = personage.Name,
                    Age = personage.Age,
                    Weight = personage.Weight,
                    History = personage.History
                }); ;
            }
            return listCharacterDto;
        }

        public bool SaveCharacter(Character character)
        {
            bool characterExist = false;
            var characters = getCharacterCRUD();
            var newcharacter = characters.Where(x => x.Id == character.Id).FirstOrDefault();

            if (newcharacter == null)
            {
                _characterRepository.SaveCharacter(character);
            }
            else
                characterExist = true;

            return characterExist;
        }

        public bool UpdateCharacter(int Id, CharacterDTO personageDTO)
        {
            bool characterExist = false;
            //var personages = getPersonageCRUD();
            var characters = _characterRepository.GetCharacter();
            var character = characters.Where(x => x.Id == Id).FirstOrDefault();

            if (character != null)
            {
                //
                _characterRepository.UpdateCharacter(character);
            }
            else
                characterExist = true;
            return characterExist;
        }
        public bool RemoveCharacter(int Id)
        {
            bool characterExist = false;
            var characters = getCharacterCRUD();
            var newCharacter = characters.Where(x => x.Id == Id).FirstOrDefault();

            if (newCharacter != null)
                _characterRepository.RemoveCharacter(Id);
            else
                characterExist = true;

            return characterExist;
        }
        public CharacterDTO GetCharacterByName(string Name)
        {
            var characters = getCharacterCRUD();
            var characterFound = characters.Where(x => x.Name == Name).FirstOrDefault();
            return characterFound;
        }

        public CharacterDTO GetCharacterByAge(int Age)
        {
            var characters = getCharacterCRUD();
            var characterFound = characters.Where(x => x.Age == Age).FirstOrDefault();
            return characterFound;
        }
    }
}
