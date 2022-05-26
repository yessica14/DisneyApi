using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Domain
{
    public class Character
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(300)]
        public String Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }

        [StringLength(600)]
        public string History { get; set; }
        public ICollection<Production> Production { get; set; }
    }
}
