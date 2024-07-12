using JustinaBack.Models;
using Microsoft.EntityFrameworkCore;

namespace JustinaBack.DAL
{


    public class CustomerRepository : Repository<CustomerEF>, ICustomerRepository
    {
        private WebAppContext _appContext;
        public CustomerRepository(WebAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }

        public async Task<CustomerEF?> GetByPublicKeyAsync(string id, bool fullCustomer)
        {
            var publicKey = Guid.Parse(id);

            IQueryable<CustomerEF> command = _appContext
                .Customers!;

            if (fullCustomer)
            {
                command = command
                .Include(e => e.User)
                .Include(e => e.User.Contact);
            }

            command = command.Where(e => e.EntityPublicKey == publicKey);

            return await command.FirstOrDefaultAsync();
        }

        public async Task<CustomerEF?> GetByUserEmailAsync(string email, bool fullCustomer)
        {
            return await _appContext
            .Customers!
            .Include(e => e.User)
            .Include(e => e.User.Contact)
            .Where(e => e.User.Email == email)
            .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<CustomerEF>> GetPaginatedStripeCustomers(PaginationVM<CustomerEF> model)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerEF updatedCustomer)
        {
            _appContext.Customers!.Update(updatedCustomer);
        }
    }
}
