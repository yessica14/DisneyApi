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
        public Qualification qualification { get; set; }
        public TypeProduction TypeProduction { get; set; }
       
    }
}
