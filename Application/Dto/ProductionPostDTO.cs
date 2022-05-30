using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class ProductionPostDTO
    {
        public string Image { get; set; }
        private string title { get; set; }
        public string Title { get => title; set => title = value.ToUpper(); }
        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }
        public TypeProduction TypeProduction { get; set; }
        public ICollection<GenderPostDto> GendersDto { get; set; }
        public ICollection<CharacterPostDTO> CharactersDto { get; set; }
    }
}
