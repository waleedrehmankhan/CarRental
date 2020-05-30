using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class ExtraDto
    {
        public int ExtraId { get; set; }
        public string Name   { get; set; }
        public float Price   { get; set; }
        public int Count   { get; set; }
        public int PriceType   { get; set; }
    }
}
