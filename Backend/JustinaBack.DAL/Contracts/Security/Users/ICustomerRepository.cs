using JustinaBack.Models;

namespace JustinaBack.DAL
{
    public interface ICustomerRepository : IRepository<CustomerEF>
    {
        Task<CustomerEF?> GetByUserEmailAsync(string email, bool fullCustomer);
        Task<CustomerEF?> GetByPublicKeyAsync(string id, bool fullCustomer);
        Task<IEnumerable<CustomerEF>> GetPaginatedStripeCustomers(PaginationVM<CustomerEF> model);
        void Update(CustomerEF updatedCustomer);
    }
}
