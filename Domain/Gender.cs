using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Domain
{
    public class Gender
    {
        public int Id { get; set; }

        [StringLength(300)]
        public String Name { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public ICollection<Production> Productions { get; set; }
    }
}
