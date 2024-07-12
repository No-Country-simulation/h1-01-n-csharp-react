using JustinaBack.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace JustinaBack.BLL
{
    public interface IBaseMasterManager : IBaseMasterManagerGF
    {

    }
    public class BaseMasterManager : BaseMasterManagerGF, IBaseMasterManager
    {
        internal readonly IUnitOfWork? _unitOfWork;
        internal readonly IEmailSender? _emailSender;
        internal readonly IHttpClientFactory? _httpClientFactory;

        internal BaseMasterManager(IUnitOfWork? unitOfWork
           , IHttpContextAccessor? httpContextAccessor
           , IEmailSender? emailSender
           , IHttpClientFactory? httpClientFactory
       ) : base(httpContextAccessor!)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _httpClientFactory = httpClientFactory;
        }
    }
}
