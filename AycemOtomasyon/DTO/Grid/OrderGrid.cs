using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO.Grid
{
    public class OrderGrid
    {
        public Guid OrderItemId { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string OrderItemStatus { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}
