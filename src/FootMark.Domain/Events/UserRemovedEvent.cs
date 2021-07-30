using NetDevPack.Messaging;
using System;

namespace FootMark.Domain.Events
{
    public class UserRemovedEvent : Event
    {
        public UserRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
