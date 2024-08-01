using Domain.Entities.Users;
using DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetPatientUser(int patientId);
        Task<List<DeletedUserGetDto>> GetDeletedUsers();
        Task<bool> IsDNIInUse(string DNI);
        bool Delete(ApplicationUser user);
        void Update(ApplicationUser user);
        Task SaveChangesAsync();
    }
}
