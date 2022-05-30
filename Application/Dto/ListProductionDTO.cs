using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Dto
{
    public class ListProductionDTO
    {
        public string Image { get; set; }
        private string title { get; set; }
        public string Title { get => title; set => title = value.ToUpper(); }
        public DateTime CreationDate { get; set; }
    }
}
