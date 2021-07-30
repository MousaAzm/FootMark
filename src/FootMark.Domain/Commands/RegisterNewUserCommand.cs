using System;

namespace FootMark.Domain.Commands
{
    public class RegisterNewUserCommand : UserCommand
    {
        public RegisterNewUserCommand(string name, string email, DateTime createDate)
        {
            Name = name;
            Email = email;
            CreateDate = createDate;
        }

    }
}
