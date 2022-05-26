using Alkemy.Disney.Api.Data.Context;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly MVCContext _context;

        public GenderRepository(MVCContext context)
        {
            _context = context;
        }
        public List<Gender> GetGender(string name)
        {
            var genders = _context.Gender.ToList();
            var gender = genders.Where(x => x.Name == name).ToList();
            return gender;
        }
    }
}
