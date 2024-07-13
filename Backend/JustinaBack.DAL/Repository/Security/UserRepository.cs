using JustinaBack.DAL.Data;
using JustinaBack.Models;
using Microsoft.EntityFrameworkCore;


namespace JustinaBack.DAL
{

    public class UserRepository : Repository<UserEF>, IUserRepository
    {
        private WebAppContext _appContext;
        public UserRepository(WebAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public async Task<UserEF?> GetByEmailAsync(string email, bool fullUser)
        {
            IQueryable<UserEF> command = _appContext.Users!;

            if (fullUser)
            {
                command = command.Include(e => e.Contact);
            }

            return await command
                .Where(e => e.Email == email)
                .FirstOrDefaultAsync();
        }

        public void Update(UserEF updatedUser)
        {
            _appContext.Users!.Update(updatedUser);
        }
    }
}
