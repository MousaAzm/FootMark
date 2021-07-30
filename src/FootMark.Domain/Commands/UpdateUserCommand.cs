using System;

namespace FootMark.Domain.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id, string name, string email, DateTime createDate)
        {
            Id = id;
            Name = name;
            Email = email;
            CreateDate = createDate;
        }
    }
}
