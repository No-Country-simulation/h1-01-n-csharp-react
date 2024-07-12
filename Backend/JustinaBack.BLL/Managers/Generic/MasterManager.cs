using JustinaBack.DAL;
using JustinaBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace JustinaBack.BLL
{
    public interface IMasterManager : IBaseMasterManager
    {
        void Save();
        Task SaveAsync();
        void AuthSave();
        Task AuthSaveAsync();
        string GetConnectionString();


    }
    public class MasterManager : BaseMasterManager, IMasterManager
    {
        private readonly UserManager<UserEF> _userManager;

        public MasterManager(IUnitOfWork? unitOfWork, IHttpContextAccessor? httpContextAccessor,
             IEmailSender? emailSender,
             IHttpClientFactory? httpClientFactory, UserManager<UserEF> userManager)
             : base(unitOfWork, httpContextAccessor, emailSender, httpClientFactory)
        {
            _userManager = userManager;
        }

        #region UnitOfWork
        public void Save()
        {
            _unitOfWork!.Save();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork!.SaveAsync();
        }

        public void AuthSave()
        {
            _unitOfWork!.AuthSave(RequestEmail());
        }

        public async Task AuthSaveAsync()
        {
            await _unitOfWork!.AuthSaveAsync(RequestEmail());
        }

        public string GetConnectionString()
        {
            return _unitOfWork!.GetConnectionString();
        }
        #endregion

    }
}
