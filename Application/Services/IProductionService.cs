using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public interface IProductionService 
    {
        List<ProductionDTO> GetMovieDtoList();
        void CreateProduction(Production production);
        List<ProductionDTO> GetMovieByTitle(string Name);
        List<ProductionDTO> GetMovieByGender(string Name);
        string GetDescription(Enum value);
    }
}
