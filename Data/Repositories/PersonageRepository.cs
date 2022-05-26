using Alkemy.Disney.Api.Data.Context;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public class PersonageRepository : IPersonageRepository
    {
        private readonly MVCContext _context;

        public PersonageRepository(MVCContext context)
        {
            _context = context;
        }
        public List<Personage> GetPersonage()
        {
            var personages = _context.Personage.ToList();
            return personages;
        }

        public void SavePersonage(Personage personage)
        {
            _context.Personage.Add(personage);
            _context.SaveChanges();
        }

        public void RemovePersonage(int Id)
        {
            var personage = _context.Personage.Where(x => x.Id == Id).FirstOrDefault();

            _context.Personage.Remove(personage);
            _context.SaveChanges();
        }
    }
}
