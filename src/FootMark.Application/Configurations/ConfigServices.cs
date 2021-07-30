using FluentValidation.Results;
using FootMark.Application.Interfaces;
using FootMark.Application.MemoryBus;
using FootMark.Application.Services;
using FootMark.Domain.Commands;
using FootMark.Domain.Events;
using FootMark.Domain.Interfaces;
using FootMark.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Configurations
{
    public static class ConfigServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserRemovedEvent>, UserEventHandler>();

            services.AddScoped<IRequestHandler<RegisterNewUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, ValidationResult>, UserCommandHandler>();
        }
    }
}
