using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
   public class MaterialDTO
    {
        public Guid MaterialId { get; set; }
        public int MaterialQuantity { get; set; }
        public string MaterialName { get; set; }
        public Guid ColourId { get; set; }
        public decimal MaterialPrice { get; set; }
        public string ColorName { get; set; }
    }
}
