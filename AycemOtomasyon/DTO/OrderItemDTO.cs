using AycemOtomasyon.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
   public class OrderItemDTO
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ColourId { get; set; }
        public int Quantity { get; set; }
        public PorductDTO Product { get; set; }
        public ColourDTO Colour { get; set; }
        public OrderItemStatus Status { get; set; }
    }
}
