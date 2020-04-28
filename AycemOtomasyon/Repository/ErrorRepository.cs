using AycemOtomasyon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.Repository
{
    public class ErrorRepository
    {
        public static bool CreateError(string message)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var error = new Error
                {
                    ErrorId = Guid.NewGuid(),
                    Message = message,
                    CreateDate = DateTime.Now
                };

                entities.Error.Add(error);

                result = entities.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static List<ErrorDTO> GetErrorList()
        {
            var result = new List<ErrorDTO>();

            try
            {
                var entities = new AycemEntities();

                result = entities.Error.Select(s => new ErrorDTO
                {
                    ErrorId = s.ErrorId,
                    Message = s.Message,
                    CreateDate = s.CreateDate
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
