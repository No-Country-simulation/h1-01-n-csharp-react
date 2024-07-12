using JustinaBack.Models;


namespace JustinaBack.DAL
{
    public interface IContactRepository : IRepository<ContactEF>
    {
        void Update(ContactEF contactEF);
    }


}
