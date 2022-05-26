using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Data.Repositories;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public class PersonajeService : IPersonageService
    {
        private IPersonageRepository _personageRepository;
        public PersonajeService(IPersonageRepository personageRepository)
        {
            _personageRepository = personageRepository;
        }
        public List<ListarPersonageDTO> getPersonage()
        {
            var personages = _personageRepository.GetPersonage();

            var listPersonageDto = new List<ListarPersonageDTO>();

            foreach (var personage in personages)
            {
                listPersonageDto.Add(new ListarPersonageDTO
                {
                    Image = personage.Image,
                    Name = personage.Name,
                }); ;
            }
            return listPersonageDto;
        }

        public List<PersonageDTO> getPersonageCRUD()
        {
            var personages = _personageRepository.GetPersonage();

            var listPersonageDto = new List<PersonageDTO>();

            foreach (var personage in personages)
            {
                listPersonageDto.Add(new PersonageDTO
                {
                    Id = personage.Id,
                    Image = personage.Image,
                    Name = personage.Name,
                    Age = personage.Age,
                    Weight = personage.Weight,
                    History = personage.History
                }); ;
            }
            return listPersonageDto;
        }

        public bool SavePersonage(Personage personage)
        {
            bool personageExist = false;
            var personages = getPersonageCRUD();
            var newpersonage = personages.Where(x => x.Id == personage.Id).FirstOrDefault();

            if(newpersonage == null)
                _personageRepository.SavePersonage(personage);
            else
                personageExist = true;

            return personageExist;
        }
        public bool RemovePersonage(int Id)
        {
            bool personageExist = false;
            var personages = getPersonageCRUD();
            var newpersonage = personages.Where(x => x.Id == Id).FirstOrDefault();

            if (newpersonage != null)
                _personageRepository.RemovePersonage(Id);
            else
                personageExist = true;

            return personageExist;
        }
        public PersonageDTO GetPersonageByName(string Name)
        {
            var personages = getPersonageCRUD();
            var characterFound = personages.Where(x => x.Name == Name).FirstOrDefault();
            return characterFound;
        }

        public PersonageDTO GetPersonageByAge(int Age)
        {
            var personages = getPersonageCRUD();
            var characterFound = personages.Where(x => x.Age == Age).FirstOrDefault();
            return characterFound;
        }
    }
}
