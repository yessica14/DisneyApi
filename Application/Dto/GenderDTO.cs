using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class GenderDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public byte[] Image { get; set; }
        public int ProductionId { get; set; }
        public ProductionDTO Production { get; set; }
    }
}
