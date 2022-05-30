using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Helper
{
    public static class Mapping
    {
        #region Converstions Character DTO
        public static CharacterDTO ConvertCharacterToDto(Character character)
        {
            var characterDto = new CharacterDTO
            {
                Id = character.Id,
                Image = Encoding.ASCII.GetString(character.Image),
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
                Image = Encoding.ASCII.GetBytes(characterdto.Image),
                Name = characterdto.Name,
                Age = characterdto.Age,
                Weight = characterdto.Weight,
                History = characterdto.History
            };

            return character;
        }

        public static List<CharacterDTO> ConverListCharacterToListDto(List<Character> listCharacter)
        {
            if (listCharacter == null)
                return null;

            var listCharacterDto = new List<CharacterDTO>();

            foreach (var character in listCharacter)
            {
                listCharacterDto.Add(ConvertCharacterToDto(character));
            }
            return listCharacterDto;
        }

        public static List<Character> ConvertirListDtoCharacterListCharacter(List<CharacterPostDTO> charactersdto)
        {
            var listCharacterDto = new List<Character>();
            foreach (var character in charactersdto)
            {
                listCharacterDto.Add(ConvertPostDtoToCharacter(character));
            }
            return listCharacterDto;
        }

        public static Character ConvertPostDtoToCharacter(CharacterPostDTO characterdto)
        {
            var character = new Character
            {
                Id = characterdto.Id,
            };

            return character;
        }

        #endregion

        #region Convertions Production DTO
        public static ListProductionDTO ConvertListProductionToDto(Production production)
        {
            var productiondto = new ListProductionDTO
            {
                Image = Encoding.ASCII.GetString(production.Image),
                Title = production.Title,
                CreationDate = production.CreationDate
            };

            return productiondto;
        }

        public static ProductionDTO ConvertProductionToDtoById(Production production)
        {
            if (production == null)
                return null;

            var productiondto = new ProductionDTO
            {
                Id = production.Id,
                Image = Encoding.ASCII.GetString(production.Image),
                Title = production.Title,
                CreationDate = production.CreationDate,
                Qualification = (int)production.qualification,
                TypeProduction = production.TypeProduction.ToString(),
                GendersDto = ConverListGenderToListDto(production.Genders.ToList()),
                PersonagesDto = ConverListCharacterToListDto(production.Characters.ToList())
            };

            return productiondto;
        }

        public static List<ProductionDTO> ConvertListProductionToListDto(List<Production> productions)
        {
            var listProductionsDto = new List<ProductionDTO>();
            foreach (var prod in productions)
            {
                listProductionsDto.Add(ConvertProductionToDtoById(prod));
            }
            return listProductionsDto;
        }

            public static Production ConvertDtoToProduction(ProductionPostDTO productiondto)
        {
            var production = new Production
            {
                Image = Encoding.ASCII.GetBytes(productiondto.Image),
                Title = productiondto.Title,
                CreationDate = DateTime.Now,
                qualification = (Qualification)productiondto.Qualification,
                TypeProduction = productiondto.TypeProduction,
                Genders = ConvertListDtoToListGender(productiondto.GendersDto.ToList()),
                Characters = ConvertirListDtoCharacterListCharacter(productiondto.CharactersDto.ToList())
            };

            return production;
        }

        #endregion

        #region Convertion Gender

        public static GenderDTO ConverGenderToDto(Gender gender)
        {
            var genderdto = new GenderDTO
            {
                Id = gender.Id,
                Name = gender.Name,
                Image = Encoding.ASCII.GetString(gender.Image)
            };
            return genderdto;
        }

        public static Gender ConvertDtoToGender(GenderPostDto genderdto)
        {
            var gender = new Gender
            {
                Id = genderdto.Id,
            };
            return gender;
        }

        public static List<GenderDTO> ConverListGenderToListDto(List<Gender> listGender)
        {
            var listGenderDto = new List<GenderDTO>();
            foreach (var gender in listGender)
            {
                listGenderDto.Add(ConverGenderToDto(gender));
            }
            return listGenderDto;
        }

        public static List<Gender> ConvertListDtoToListGender(List<GenderPostDto> gendersdto)
        {
            var listGender = new List<Gender>();
            foreach (var genderdto in gendersdto)
            {
                listGender.Add(ConvertDtoToGender(genderdto));
            }
            return listGender;
        }

        #endregion
    }
}
