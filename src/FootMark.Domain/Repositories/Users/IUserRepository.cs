using FootMark.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Domain.Repositories.Users
{
    public interface IUserRepository
    {
        Task<bool> Add(AppUser user);
        Task<bool> Update(AppUser user);
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetById(string id);
        Task<bool> Delete(string id);
    }
}
