using FluentValidation.Results;
using FootMark.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootMark.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(Guid id);

        Task<ValidationResult> AddAsync(UserViewModel user);
        Task<ValidationResult> UpdateAsync(UserViewModel user);
        Task<ValidationResult> RemoveAsync(Guid id);

    }
}
