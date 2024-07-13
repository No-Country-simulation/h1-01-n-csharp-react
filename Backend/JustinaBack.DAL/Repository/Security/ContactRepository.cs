using JustinaBack.DAL.Data;
using JustinaBack.Models;


namespace JustinaBack.DAL
{

    public class ContactRepository : Repository<ContactEF>, IContactRepository
    {
        private WebAppContext _appContext;
        public ContactRepository(WebAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
        public void Update(ContactEF updatedContact)
        {
            _appContext.Contacts!.Update(updatedContact);
        }
    }
}