using AycemOtomasyon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AycemOtomasyon.Repository
{
    public static class UserRepository
    {
        public static List<UserDTO> GetUserList(string username = "", string phone = "", string firstName = "", string surname = "", Guid? department = null)
        {
            var result = new List<UserDTO>();

            try
            {
                var entities = new AycemEntities();

                var query = entities.User.Include("Role").Where(q => q.Username != string.Empty);

                if (!string.IsNullOrEmpty(username))
                {
                    query = query.Where(q => q.Username.ToLower().Contains(username.ToLower()));
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    query = query.Where(q => q.Phone.ToLower().Contains(phone.ToLower()));
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    query = query.Where(q => q.FirstName.ToLower().Contains(firstName.ToLower()));
                }
                if (!string.IsNullOrEmpty(surname))
                {
                    query = query.Where(q => q.Surname.ToLower().Contains(surname.ToLower()));
                }
                if (department.HasValue && department.Value != Guid.Empty)
                {
                    query = query.Where(q => q.RoleId == department);
                }

                result = query.Select(s => new UserDTO
                {
                    UserId = s.UserId,
                    Username = s.Username,
                    Phone = s.Phone,
                    FirstName = s.FirstName,
                    Surname = s.Surname,
                    RoleId = s.RoleId.Value,
                    RoleName = s.Role.Name
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public static UserDTO GetUser(Guid userId)
        {
            var result = new UserDTO();

            try
            {
                var entities = new AycemEntities();

                result = entities.User.Include("Role").Where(u => u.UserId == userId).Select(s => new UserDTO
                {
                    UserId = s.UserId,
                    Username = s.Username,
                    FirstName = s.FirstName,
                    Surname = s.Surname,
                    Phone = s.Phone,
                    Password = s.Password,
                    RoleId = s.RoleId.Value,
                    Role = s.Role
                }).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public static UserDTO Login(string username, string password)
        {
            //TODO: Username ve password için validation'lar yapılacak.

            var result = new UserDTO();

            try
            {
                var entities = new AycemEntities();

                result = entities.User.Where(q => q.Username == username && q.Password == password).Select(s => new UserDTO
                {

                    UserId = s.UserId,
                    Username = s.Username,
                    FirstName = s.FirstName,
                    Surname = s.Surname,
                    Phone = s.Phone,
                    RoleId = s.RoleId.Value

                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;//Bilgi yanlışsa buraya exception geliyor.
            }

            CurrentUser.LoginUser = result;
            return result;
        }

        public static UserDTO ForgotPassword(string username, string phone)
        {

            var result = new UserDTO();

            try
            {
                var entities = new AycemEntities();

                result = entities.User.Where(q => q.Username == username && q.Phone == phone).Select(s => new UserDTO
                {
                    Username = s.Username,
                    Phone = s.Phone


                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;//Bilgi yanlışsa buraya exception geliyor.
            }

            return result;

        }

        public static bool CreateUser(string username, string firstname, string surname, string phone, string password, Guid roleId)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var user = new User
                {
                    UserId = Guid.NewGuid(),
                    Username = username,
                    FirstName = firstname,
                    Surname = surname,
                    Phone = phone,
                    Password = password,
                    RoleId = roleId
                };

                entities.User.Add(user);
                result = entities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
        public static bool UpdateUser(Guid userId, string username, string firstname, string surname, string phone, string password, Guid roleId)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var user = entities.User.Where(u => u.UserId == userId).FirstOrDefault();

                if (user != null)
                {
                    user.Username = username;
                    user.FirstName = firstname;
                    user.Surname = surname;
                    user.Phone = phone;
                    user.Password = password;
                    user.RoleId = roleId;

                    result = entities.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public static bool DeleteUser(Guid userId)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();
                var user = entities.User.Where(p => p.UserId == userId).Select(p => p).FirstOrDefault();
                entities.User.Remove(user);
                result = entities.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
        //Role için deneme

        public static Dictionary<Guid, string> GetRoleList()
        {
            var result = new Dictionary<Guid, string>();

            try
            {
                var entities = new AycemEntities();
                result = entities.Role.ToDictionary(r => r.RoleId, r => r.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        //Buraya kadar.
        public static bool ChangePassword(Guid userId, string newPassword)
        {
            var result = false;

            try
            {
                var entities = new AycemEntities();

                var user = entities.User.FirstOrDefault(u => u.UserId == userId);

                user.Password = newPassword;

                result = entities.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public static bool HasRightToAccess(Guid roleId, Guid pageId)
        {


            var result = false;

            try
            {
                var entities = new AycemEntities();


                result = entities.Permission.Any(x => x.RoleId == roleId && x.PageId == pageId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;
        }

        public static List<Page> GetUserPages()
        {
            var result = new List<Page>();

            try
            {
                var entities = new AycemEntities();
                result = entities.Permission.Include("Page").Where(p => p.RoleId == CurrentUser.LoginUser.RoleId).Select(p => p.Page).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

    }
}

