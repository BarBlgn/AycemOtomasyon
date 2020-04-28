using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
    public class ErrorDTO
    {
        public Guid ErrorId { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
