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
        private int isMovie = 2;
        public ProductionRepository(MVCContext context)
        {
            _context = context;
        }
        public List<Production> GetMovies()
        {
            var productions =  _context.Production.ToList();
            return productions;
        }

        public void SaveMovie(Production production)
        {
            var existproduction = _context.Production.Where(x => x.Title == production.Title).FirstOrDefault();
            
            if(existproduction == null)
            {
                var newProduction = new Production();
                isMovie = (int)newProduction.TypeProduction;
                newProduction.TypeProduction = (TypeProduction)isMovie;
                newProduction.Id = production.Id;
                newProduction.Image = production.Image;
                newProduction.Title = production.Title;
                newProduction.CreationDate = production.CreationDate;
                newProduction.qualification = production.qualification;
                _context.Production.Add(newProduction);
            }
        }

    }
}
