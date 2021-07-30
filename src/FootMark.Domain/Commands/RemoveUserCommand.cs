using System;

namespace FootMark.Domain.Commands
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }


    }
}
