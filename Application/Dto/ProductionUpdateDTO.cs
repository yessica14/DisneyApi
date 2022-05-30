using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class ProductionUpdateDTO
    {
        public int Id { get; set; }

        public string Image { get; set; }

        private string title { get; set; }
        public string Title { get => title; set => title = value.ToUpper(); }

        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }
        public string TypeProduction { get; set; }
        public ICollection<int> GendersDto { get; set; }
        public ICollection<int> CharactersDto { get; set; }
    }
}
