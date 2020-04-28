using AycemOtomasyon.DTO;
using AycemOtomasyon.DTO.Enum;
using AycemOtomasyon.DTO.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AycemOtomasyon.Repository
{
    public static class ProductRepository
    {
        public static bool CreateProduct(string productName)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var porduct = new Porduct
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = productName
                };

                entities.Porduct.Add(porduct);

                result = entities.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                throw;
            }
            return result;
        }
        public static List<PorductDTO> GetProducts()
        {
            var result = new List<PorductDTO>();

            try
            {
                var entities = new AycemEntities();

                result = entities.Porduct.Select(c => new PorductDTO
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName
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
