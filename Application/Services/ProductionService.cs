using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public class ProductionService : IProductionService
    {
        private IProductionRepository _productionRepository;
        private IGenderRepository _genderRepository;
        public int TypeProductionIsMovie = 2;
        private IGenderService _genderService;

        public ProductionService(IProductionRepository productionRepository, IGenderService genderService )
        {
            _productionRepository = productionRepository;
            _genderService = genderService;
        }

        public List<ProductionDTO> GetMovieDtoList()
        {
            var productions = _productionRepository.GetMovies();
           
            var listMovieDto = new List<ProductionDTO>();

            foreach (var production in productions)
            {
                if((int)production.TypeProduction == TypeProductionIsMovie)
                {
                    listMovieDto.Add(new ProductionDTO
                    {
                        Id = production.Id,
                        Image = production.Image,
                        Title = production.Title,
                        CreationDate = production.CreationDate,
                        Qualification = (int)production.qualification,
                        TypeProduction = GetDescription(production.TypeProduction)
                    }); ;
                }
               
            }
            return listMovieDto;
        }
        public void CreateProduction(Production production)
        {
            _productionRepository.SaveMovie(production);
        }

        public List<ProductionDTO> GetMovieByTitle(string Name)
        {
            var productions = _productionRepository.GetMovies();

            var listMovieDto = new List<ProductionDTO>();
            
            foreach (var production in productions)
            {
                if ((int)production.TypeProduction == TypeProductionIsMovie && production.Title == Name)
                {
                    listMovieDto.Add(new ProductionDTO
                    {
                        Id = production.Id,
                        Image = production.Image,
                        Title = production.Title,
                        CreationDate = production.CreationDate,
                        Qualification = (int)production.qualification,
                        TypeProduction = GetDescription(production.TypeProduction)
                    }); ; ;
                }
            }
            return listMovieDto;
        }

        public List<ProductionDTO> GetMovieByGender(string Name)
        {
            var productions = _productionRepository.GetMovies();
            //var gender = _genderRepository.GetGender();
            var genders = _genderService.GetGender(Name);
            var listMovieDto = new List<ProductionDTO>();
            foreach (var production in productions)
            {
                foreach(var gender in genders){
                    if ((int)production.TypeProduction == TypeProductionIsMovie && production.Id == gender.ProductionId)
                    {
                        listMovieDto.Add(new ProductionDTO
                        {
                            Id = production.Id,
                            Image = production.Image,
                            Title = production.Title,
                            CreationDate = production.CreationDate,
                            Qualification = (int)production.qualification,
                            TypeProduction = GetDescription(production.TypeProduction),
                            Genders = genders
                        }); ;
                    }
                }
            }
            return listMovieDto;
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

        //public void AgragarPeli(PeliculaDto peliDto)
        //{
        //    peliDto.fechaCarga = DateTime.Now;

        //    var peli = _repoPelis.ObternerPeli(peliDto.nombre);
        //    if (peli != null)
        //        repo.AgregarPeli(peli);
        //    else
        //        msjError();
        //}

        //public void AgragarPeli(Venta venta)
        //{
        //    venta.Total = venta.Item1.precio + venta.Item2.precio
        //}

    }
}
