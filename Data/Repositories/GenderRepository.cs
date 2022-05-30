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

        public List<Gender> GetGenderToListGender(List<Gender> genders)
        {
            var listGender = new List<Gender>();
            var gendersDb = _context.Gender.ToList();

            foreach (var gen in genders)
            {
                var g = gendersDb.Where(x => x.Id == gen.Id).FirstOrDefault();
                if(g != null)
                    listGender.Add(g);
            }

            return listGender;
        }

        public List<Gender> GetGenderToListGender(List<int> genders)
        {
            var listGender = new List<Gender>();
            var gendersDb = _context.Gender.ToList();

            foreach (var gen in genders)
            {
                var g = gendersDb.Where(x => x.Id == gen).FirstOrDefault();
                if (g != null)
                    listGender.Add(g);
            }

            return listGender;
        }
    }
}
