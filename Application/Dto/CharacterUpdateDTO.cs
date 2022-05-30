using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class CharacterUpdateDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        private string name;
        public string Name { get => name; set => name = value.ToUpper(); }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
    }
}
