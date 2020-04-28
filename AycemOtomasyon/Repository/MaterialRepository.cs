using System;
using AycemOtomasyon.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.Repository
{
    class MaterialRepository
    {
        public static bool CreateMaterial(MaterialDTO materialDTO)
        {
            var result = false;
            try
            {
                var entities = new AycemEntities();

                var material = new Material
                {
                    MaterialId = materialDTO.MaterialId,
                    MaterialName = materialDTO.MaterialName,
                    MaterialQuantity = materialDTO.MaterialQuantity,
                    ColourId = materialDTO.ColourId,
                    MaterialPrice = materialDTO.MaterialPrice
                };

                entities.Material.Add(material);

                result = entities.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                throw;
            }
            return result;
        }
        public static List<MaterialDTO> GetMaterials()
        {
            var result = new List<MaterialDTO>();

            try
            {
                var entities = new AycemEntities();

                result = entities.Material.Include("Colour").Select(m => new MaterialDTO
                {
                    MaterialId = m.MaterialId,
                    MaterialName = m.MaterialName,
                    MaterialQuantity = m.MaterialQuantity,
                    ColourId = m.ColourId.Value,
                    MaterialPrice = m.MaterialPrice,
                    ColorName = m.Colour.ColourName
                }).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
