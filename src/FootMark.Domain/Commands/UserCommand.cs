using NetDevPack.Messaging;
using System;

namespace FootMark.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime CreateDate { get; protected set; }
    }
}
