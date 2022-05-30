using Alkemy.Disney.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public interface IProductionRepository
    {
        List<Production> GetMovies();
        Production GetDetailProductionById(int Id);
        List<Production> GetSerie();
        List<Production> GetMoviesByTitle(string Name);
        Production GetMoviesFilterByTitle(string Name);
        List<Production> GetMovieByGender(int genero);
        Production GetMovieById(int Id);
        void SaveMovie(Production production);
        void UpdateProduction(Production production);
        void RemoveProduction(int Id);
    }
}
