using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Domain.Commands.Validations
{
    public class RemoveUserValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserValidation()
        {
            ValidateId();
        }
    }
}
