using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using Alkemy.Disney.Api.Domain;
using Alkemy.Disney.Api.Helper;
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
            var characters = _characterRepository.GetCharacterList();

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

        public List<CharacterDTO> getCharacterList()
        {
            var personages = _characterRepository.GetCharacterList();

            var listCharacterDto = new List<CharacterDTO>();

            foreach (var personage in personages)
            {
                listCharacterDto.Add(Mapping.ConvertCharacterToDto(personage));
            }
            return listCharacterDto;
        }

        public OperationResponseDTO SaveCharacter(CharacterDTO characterDTO)
        {
            var operation = new OperationResponseDTO();
           
            try
            {
                var character = _characterRepository.getCharacterByName(characterDTO.Name);

                if (character == null)
                {
                    _characterRepository.SaveCharacter(Mapping.ConvertDtoToCharacter(characterDTO));
                    operation.CompletedOperation = true;
                }
                else
                {
                    operation.CompletedOperation = false;
                    operation.Detail = $"No se puede guardar porque ya existe un personaje con el nombre {characterDTO.Name}";
                }
            }
            catch(Exception e)
            {
                operation.CompletedOperation = false;
                operation.Detail = e.Message;
            }
            
            return operation;
        }

        public OperationResponseDTO UpdateCharacter(int Id, CharacterDTO characterDTO)
        {
            var operation = new OperationResponseDTO();
            try
            {
                var character = _characterRepository.getCharacterById(characterDTO.Id);
                if (character != null)
                {
                    //Image = characterdto.Image,
                    character.Name = characterDTO.Name;
                    character.Age = characterDTO.Age;
                    character.Weight = characterDTO.Weight;
                    character.History = characterDTO.History;

                    _characterRepository.UpdateCharacter(character);

                    operation.CompletedOperation = true;
                }
                else
                {
                    operation.CompletedOperation = false;
                    operation.Detail = $"No se puede realizar la actualizacion porque aun no existe el personaje con este nombre {characterDTO.Name} por favor dirigase a guardar";
                }
            }
            catch(Exception e)
            {
                operation.CompletedOperation = false;
                operation.Detail = e.Message;
            }
            return operation;
        }
        public OperationResponseDTO RemoveCharacter(int Id)
        {
            var operation = new OperationResponseDTO();
            try
            {
                var character = _characterRepository.getCharacterById(Id);

                if (character != null)
                {
                    _characterRepository.RemoveCharacter(Id);
                    operation.CompletedOperation = true;
                }
                else
                {
                    operation.CompletedOperation = false;
                    operation.Detail = $"No se puede eliminar el personaje porque no existe un personaje con este {Id} ";
                }
            }
            catch (Exception e)
            {
                operation.CompletedOperation = false;
                operation.Detail = e.Message;
            }
            return operation;
        }
        public CharacterDTO GetCharacterByName(string Name)
        {
            Object characterdto = null;
            var character = _characterRepository.getCharacterByName(Name.ToLower());
            if (character != null)
                characterdto = Mapping.ConvertCharacterToDto(character);
            return (CharacterDTO)characterdto;
        }

        public CharacterDTO GetCharacterByAge(int Age)
        {
            Object characterdto = null;
            var character = _characterRepository.getCharacterByAge(Age);
            if (character != null)
                characterdto = Mapping.ConvertCharacterToDto(character);
            return (CharacterDTO)characterdto;
        }
    }
}
