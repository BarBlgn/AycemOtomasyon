using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
    class ProdutDTO
    {
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductName { get; set; }
        public string ProductColour { get; set; }
    }
}
