using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public interface IGenderService
    {
        List<GenderDTO> GetGender(string name);
    }
}
