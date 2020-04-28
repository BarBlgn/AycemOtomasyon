using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AycemOtomasyon.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string RoleName { get; set; }
    }
}
