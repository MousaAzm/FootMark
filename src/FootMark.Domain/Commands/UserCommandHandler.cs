using FluentValidation.Results;
using FootMark.Domain.Events;
using FootMark.Domain.Interfaces;
using FootMark.Domain.Models.Users;
using MediatR;
using NetDevPack.Messaging;
using System;
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

        public async Task<ValidationResult> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = new AppUser(message.Id, message.Name, message.Email, message.CreateDate);
            var existingUser = await _repo.GetByEmail(user.Email);

            if (existingUser != null && existingUser.Id != user.Id)
            {
                if (!existingUser.Equals(user))
                {
                    AddError("The user e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            user.AddDomainEvent(new UserUpdatedEvent(user.Id, user.Name, user.Email, user.CreateDate));

            _repo.Update(user);

            return await Commit(_repo.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = await _repo.GetById(message.Id);

            if (user is null)
            {
                AddError("The user doesn't exists.");
                return ValidationResult;
            }

            user.AddDomainEvent(new UserRemovedEvent(message.Id));

            _repo.Remove(user);

            return await Commit(_repo.UnitOfWork);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
