using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserDto userDto);
        Task<UserDto> UpdateAsync(UserDto userDto);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id);
        Task<UserDto> DeleteAsync(string id);
    }
}
