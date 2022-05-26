using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public class GenderService : IGenderService
    {
        private IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public List<GenderDTO> GetGender(string name)
        {
            var genders = _genderRepository.GetGender(name);

            var listGenderDto = new List<GenderDTO>();
            foreach(var gender in genders)
            {
                listGenderDto.Add(new GenderDTO
                {
                    Id = gender.Id,
                    Name = gender.Name,
                    Image = gender.Image,
                    ProductionId = gender.ProductionId
                });
            }
            return listGenderDto.ToList();
        }
    }
}
