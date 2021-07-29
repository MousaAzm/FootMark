using AutoMapper;
using FluentValidation.Results;
using FootMark.Application.Interfaces;
using FootMark.Application.ViewModels;
using FootMark.Domain.Commands;
using FootMark.Domain.Interfaces;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        private readonly IMediatorHandler _mediator;

        public UserService(IMapper mapper, IUserRepository customerRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _repo = customerRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _repo.GetAll());
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UserViewModel>(await _repo.GetById(id));
        }

        public async Task<ValidationResult> AddAsync(UserViewModel user)
        {
            var registerCommand = _mapper.Map<RegisterNewUserCommand>(user);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> UpdateAsync(UserViewModel user)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(user);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> RemoveAsync(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
