using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Context;
using Alkemy.Disney.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly MVCContext _context;
        public ProductionRepository(MVCContext context)
        {
            _context = context;
        }

        public List<Production> GetMovies()
        {
            var productions = _context.Production.Where(x => x.TypeProduction == TypeProduction.MOVIE).ToList();
            return productions;
        }

        public Production GetDetailProductionById(int Id)
        {
            var production = _context.Production
                 .Include(x => x.Genders)
                 .Include(x => x.Characters)
                 .Where(x => x.Id == Id)
                 .FirstOrDefault();

            return production;
        }

        public List<Production> GetSerie()
        {
            var productions = _context.Production.Where(x => x.TypeProduction == TypeProduction.SERIE).ToList();
            return productions;
        }

        public List<Production> GetMoviesByTitle(string Name)
        {
            var productions = _context.Production.Where(x => x.Title.Contains(Name)).ToList();
            return productions;
        }

        public Production GetMoviesFilterByTitle(string Name)
        {
            var production = _context.Production.Where(x => x.Title == Name).FirstOrDefault();
            return production;
        }

        public List<Production> GetMovieByGender(int idGenero)
        {
            var productions = _context.Production
                .Include(x => x.Genders);

            var listProduction = new List<Production>();

            foreach (var prod in productions)
            {
                if (prod.Genders.Any(x => x.Id == idGenero))
                    listProduction.Add(prod);
            }
            
            return listProduction;
        }

        public Production GetMovieById(int Id)
        {
            var production = _context.Production.Where(x => x.Id == Id).FirstOrDefault();
            return production;
        }

        public List<Production> SortProductionByDate(string typeOrder)
        {
            List<Production> production = null;

            if(typeOrder == "ASC")
                production = _context.Production.OrderBy(x => x.CreationDate)
                    .Include(x => x.Genders)
                    .Include(x => x.Characters)
                    .ToList();
            else
                production = _context.Production.OrderByDescending(x => x.CreationDate)
                    .Include(x => x.Genders)
                    .Include(x => x.Characters)
                    .ToList();

            return production;
        }

        public void SaveMovie(Production production)
        {
            _context.Production.Add(production);
            _context.SaveChanges();
        }

        public void UpdateProduction(Production production)
        {
            try
            {
                _context.Production.Attach(production);
                _context.Entry(production).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void RemoveProduction(int Id)
        {
            var production = _context.Production.Where(x => x.Id == Id).FirstOrDefault();

            _context.Production.Remove(production);
            _context.SaveChanges();
        }

    }
}
