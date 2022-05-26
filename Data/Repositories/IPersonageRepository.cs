using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public interface IPersonageRepository
    {
        List<Personage> GetPersonage();
        void SavePersonage(Personage personage);
        void RemovePersonage(int Id);
    }
}
