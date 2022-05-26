using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public interface IPersonageService
    {
        List<ListarPersonageDTO> getPersonage();

        List<PersonageDTO> getPersonageCRUD();
        bool SavePersonage(Personage personage);

        bool RemovePersonage(int Id);

        PersonageDTO GetPersonageByName(string Name);

        PersonageDTO GetPersonageByAge(int Age);
    }
}
