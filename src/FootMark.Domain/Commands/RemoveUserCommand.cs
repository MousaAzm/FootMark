using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
