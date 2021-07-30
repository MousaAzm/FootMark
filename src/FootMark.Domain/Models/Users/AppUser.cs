using NetDevPack.Domain;
using System;

namespace FootMark.Domain.Models.Users
{
    public class AppUser : Entity, IAggregateRoot
    {
        public AppUser(Guid id, string name, string email, DateTime createDate)
        {
            Id = id;
            Name = name;
            Email = email;
            CreateDate = createDate;
        }

        public AppUser()
        {
            Id = Id;
            Name = Name;
            Email = Email;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
