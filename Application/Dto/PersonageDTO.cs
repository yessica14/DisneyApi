using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class PersonageDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        public String Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }

        public string History { get; set; }

       // public ICollection<ProductionDTO> Production { get; set; }
    }
}
