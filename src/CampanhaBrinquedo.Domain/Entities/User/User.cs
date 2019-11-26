namespace CampanhaBrinquedo.Domain.Entities.User
{
    using System;

    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        protected User() : base() { }

        public User(string name, string email, string password) : base()
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
        }

        public User(Guid id, string name, string email, string password) : base()
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}