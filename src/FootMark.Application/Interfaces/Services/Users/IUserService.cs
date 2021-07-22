using FootMark.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserDto userDto);
        Task<bool> UpdateAsync(UserDto userDto);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
    }
}
