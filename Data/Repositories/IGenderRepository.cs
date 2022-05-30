using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Data.Repositories
{
    public interface IGenderRepository
    {
        List<Gender> GetGender(string name);
        List<Gender> GetGenderToListGender(List<Gender> genders);
        List<Gender> GetGenderToListGender(List<int> genders);
    }
}
