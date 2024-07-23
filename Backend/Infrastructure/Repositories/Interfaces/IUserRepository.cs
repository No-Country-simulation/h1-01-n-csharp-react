using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsDNIInUse(string DNI);
        void Update(ApplicationUser user);
        Task SaveChangesAsync();
    }
}
