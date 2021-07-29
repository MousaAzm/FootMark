using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
