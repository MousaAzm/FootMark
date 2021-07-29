using System;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootMark.Application.ViewModels;

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
