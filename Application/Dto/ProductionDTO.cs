using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class ProductionDTO
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }
        public string TypeProduction { get; set; }
        public ICollection<GenderDTO> Genders { get; set; }
        public ICollection<CharacterDTO> Personages { get; set; }

    }
}
