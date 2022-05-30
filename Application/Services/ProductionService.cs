using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using Alkemy.Disney.Api.Domain;
using Alkemy.Disney.Api.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public class ProductionService : IProductionService
    {
        private IProductionRepository _productionRepository;
        private IGenderRepository _genderRepository;
        private IGenderService _genderService;
        private ICharacterRepository _characterRepository;

        public ProductionService(IProductionRepository productionRepository, IGenderService genderService, IGenderRepository genderRepository, ICharacterRepository characterRepository)
        {
            _productionRepository = productionRepository;
            _genderService = genderService;
            _genderRepository = genderRepository;
            _characterRepository = characterRepository;
        }

        public List<ListProductionDTO> GetMovieDtoList()
        {
            var productions = _productionRepository.GetMovies();
           
            var listMovieDto = new List<ListProductionDTO>();

            foreach (var production in productions)
            {
                listMovieDto.Add(Mapping.ConvertListProductionToDto(production));
            }
            return listMovieDto;
        }

        public ProductionDTO GetDetailProductionById(int Id)
        {
            var production = _productionRepository.GetDetailProductionById(Id);
            var productioDto = Mapping.ConvertProductionToDtoById(production);
            return productioDto;
        }

        public OperationResponseDTO SaveProduction(ProductionPostDTO productiondto)
        {
            var operation = new OperationResponseDTO();

            try
            {
                var production = _productionRepository.GetMoviesFilterByTitle(productiondto.Title);

                if (production == null)
                {
                    var aux = Mapping.ConvertDtoToProduction(productiondto);

                    aux.Genders = _genderRepository.GetGenderToListGender(aux.Genders.ToList());
                    aux.Characters = _characterRepository.GetCharacterToListCharacter(aux.Characters.ToList());

                    _productionRepository.SaveMovie(aux);
                    operation.CompletedOperation = true;
                }
                else
                {
                    operation.CompletedOperation = false;
                    operation.Detail = $"No se puede guardar la misma pelicula {productiondto.Title} porque ya existe";
                }
            }
            catch (Exception e)
            {
                operation.CompletedOperation = false;
                operation.Detail = e.Message;
            }

            return operation;
        }
        public OperationResponseDTO UpdateProduction(int id, ProductionUpdateDTO productiondto)
        {
            var operation = new OperationResponseDTO();
            try
            {
                var production = _productionRepository.GetDetailProductionById(productiondto.Id);

                if (production != null)
                {
                    production.Id = productiondto.Id;
                    production.Image = Encoding.ASCII.GetBytes(productiondto.Image);
                    production.Title = productiondto.Title;
                    production.CreationDate = productiondto.CreationDate;
                    production.qualification = (Qualification)productiondto.Qualification;
                    production.TypeProduction = (TypeProduction)Enum.Parse(typeof(TypeProduction), productiondto.TypeProduction);
                    production.Genders = _genderRepository.GetGenderToListGender(productiondto.GendersDto.ToList());
                    production.Characters = _characterRepository.GetCharacterToListCharacter(productiondto.CharactersDto.ToList());

                    _productionRepository.UpdateProduction(production);
                    operation.CompletedOperation = true;
                }
                else
                {
                    operation.CompletedOperation = false;
                    operation.Detail = $"No se puede realizar la actualizacion porque aun no existe la pelicula con este nombre {productiondto.Title} por favor dirigase a guardar";
                }
            }
            catch (Exception e)
            {
                operation.CompletedOperation = false;
                operation.Detail = e.Message;
            }
            return operation;
        }

        public OperationResponseDTO RemoveProduction(int Id)
        {
            var operation = new OperationResponseDTO();
            try
            {
                var production = _productionRepository.GetMovieById(Id);

                if (production != null)
                {
                    _productionRepository.RemoveProduction(Id);
                    operation.CompletedOperation = true;
                }
                else
                {
                    operation.CompletedOperation = false;
                    operation.Detail = $"No se puede eliminar la produccion porque no existe una produccion con este {Id} ";
                }
            }
            catch (Exception e)
            {
                operation.CompletedOperation = false;
                operation.Detail = e.Message;
            }
            return operation;
        }

        public List<ListProductionDTO> GetMovieByTitle(string Name)
        {
            var productions = _productionRepository.GetMoviesByTitle(Name);
            var listMovieDto = new List<ListProductionDTO>();

            foreach (var production in productions)
            {
                listMovieDto.Add(Mapping.ConvertListProductionToDto(production));
            }
            return listMovieDto;
        }

        public List<ListProductionDTO> GetMovieByGender(int gender)
        {
            var productions = _productionRepository.GetMovieByGender(gender);
            var listMovieDto = new List<ListProductionDTO>();
            foreach (var production in productions)
            {
                listMovieDto.Add(Mapping.ConvertListProductionToDto(production));
            }
            return listMovieDto;
        }

        public List<ProductionDTO> SortProductionByDate(string typeOrder)
        {
            var productions = _productionRepository.SortProductionByDate(typeOrder);
            
            var listProductionDto = Mapping.ConvertListProductionToListDto(productions);

            return listProductionDto;
        }

        public string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                      (DescriptionAttribute[])fi.GetCustomAttributes(
                            typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ?
                      attributes[0].Description :
                      value.ToString();
        }
    }
}
