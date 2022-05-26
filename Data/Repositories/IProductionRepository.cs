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
        void SaveMovie(Production production);
    }
}
