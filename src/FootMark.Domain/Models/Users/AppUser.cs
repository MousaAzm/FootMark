using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Domain.Models.Users
{
    public class AppUser : Entity , IAggregateRoot
    {
        public AppUser(Guid id, string name, string email, DateTime createDate)
        {
            Id = id;
            Name = name;
            Email = email;
            CreateDate = createDate;
        }

        
        protected AppUser()
        {
            Id = Id;
            Name = Name;
            Email = Email;
            
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime CreateDate { get; private set; }
    }
}
