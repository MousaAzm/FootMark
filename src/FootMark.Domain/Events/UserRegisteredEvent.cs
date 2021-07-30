using NetDevPack.Messaging;
using System;

namespace FootMark.Domain.Events
{
    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(Guid id, string name, string email, DateTime createDate)
        {
            Id = id;
            Name = name;
            Email = email;
            CreateDate = createDate;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime CreateDate { get; private set; }
    }
}
