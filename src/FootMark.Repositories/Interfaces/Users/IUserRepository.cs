using FootMark.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Repositories.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<AppUser> Add(AppUser user);
        Task<AppUser> Update(AppUser user);
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetById(string id);
        Task<AppUser> Delete(string id);
    }
}
