using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
    public class OrderDTO
    {

        public Guid OrderId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ModifierRoleId { get; set; }
        public Guid ColourId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime OrderExpiryDate { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public List<PorductDTO> Products { get; set; }
        public CompanyDTO Company { get; set; }
        public ColourDTO Colours { get; set; }
    }
}
