using System;

namespace WebApplication1.ViewModels
{
    public class UserViewModel
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
