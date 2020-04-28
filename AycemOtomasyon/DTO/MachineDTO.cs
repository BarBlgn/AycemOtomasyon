using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
    public class MachineDTO
    {
        public Guid MachineId { get; set; }
        public string MachineName { get; set; }
        public int ProductionCapacity { get; set; }
        public int ProductionFail { get; set; }
    }
}
