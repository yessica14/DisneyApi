using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Domain
{
    public class Production
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [StringLength(300)]
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public Qualification qualification { get; set; }
        public TypeProduction TypeProduction { get; set; }
        public ICollection<Gender> Gender { get; set; }
        public ICollection<Personage> Personages { get; set; }
    }
}
