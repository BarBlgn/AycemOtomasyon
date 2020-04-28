using AycemOtomasyon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.Repository
{
    class MachineRepository
    {
        public static List<MachineDTO> GetMachine()
        {
            var result = new List<MachineDTO>();
            try
            {
                var entities = new AycemEntities();
                result = entities.Machines.Select(s => new MachineDTO
                {
                    MachineId = s.MachineId,
                    MachineName = s.MachineName,
                    ProductionCapacity = s.ProductionCapacity,
                    ProductionFail = s.ProductionFail
                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
        public static bool CreateMachine(string machineName, int productionCapacity, int productionFail)
        {
            var result = false;
            try
            {
                var entities = new AycemEntities();
                var machine = new Machines
                {
                    MachineId = Guid.NewGuid(),
                    MachineName = machineName,
                    ProductionCapacity = productionCapacity,
                    ProductionFail = productionFail
                };
                entities.Machines.Add(machine);
                result = entities.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }


    }
}
