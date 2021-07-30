using FluentValidation.Results;
using FootMark.Domain.Interfaces;
using FootMark.Domain.Models.Users;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootMark.Domain.Commands
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>,
        IRequestHandler<RemoveUserCommand, ValidationResult>
    {
        private readonly IUserRepository _repo;

        public UserCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ValidationResult> Handle(RegisterNewUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = new AppUser(Guid.NewGuid(), message.Name, message.Email, message.CreateDate);

            if (await _repo.GetByEmail(user.Email) != null)
            {
                AddError("The user e-mail has already been taken.");
                return ValidationResult;
            }

            user.AddDomainEvent(new UserRegisteredEvent(user.Id, user.Name, user.Email, user.CreateDate));

            _repo.Add(user);

            return await Commit(_repo.UnitOfWork);
        }
    }
}
