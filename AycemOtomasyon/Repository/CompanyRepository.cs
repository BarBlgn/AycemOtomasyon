using AycemOtomasyon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.Repository
{
    public static class CompanyRepository
    {
        public static bool CreateCompany(string name, string phone)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var company = new Company
                {
                    CompanyId = Guid.NewGuid(),
                    CompanyName = name,
                    CompanyTelNo = phone
                };

                entities.Company.Add(company);
                result = entities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public static List<CompanyDTO> GetCompanies() 
        {
            var result = new List<CompanyDTO>();

            try
            {
                var entities = new AycemEntities();

                result = entities.Company.Select(c => new CompanyDTO
                {
                    CompanyId = c.CompanyId,
                    CompanyName = c.CompanyName,
                    CompanyTelNo = c.CompanyTelNo
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
