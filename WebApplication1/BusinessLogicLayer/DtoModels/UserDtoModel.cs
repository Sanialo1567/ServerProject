using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class UserDtoModel
    {
        public Guid Id { get; set; }

        public string Mail { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        Owner,
        Reader
    }
}
