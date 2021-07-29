using FootMark.Domain.Models.Users;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Domain.Interfaces
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetById(Guid id);
        Task<AppUser> GetByEmail(string email);

        void Add(AppUser user);
        void Update(AppUser user);
        void Remove(AppUser user);
    }
}
