using System;
using AycemOtomasyon.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.Repository
{
    public static class ColourRepository
    {
        public static List<ColourDTO> GetColours()
        {
            var result = new List<ColourDTO>();

            try
            {
                var entities = new AycemEntities();

                result = entities.Colour.Select(c => new ColourDTO
                {
                    ColourId = c.ColourId,
                    ColourName = c.ColourName
                }).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}
