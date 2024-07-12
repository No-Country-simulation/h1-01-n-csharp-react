using JustinaBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace JustinaBack.BLL
{
    public interface IBaseMasterManagerGF
    {
        string RequestEmail();
        ObjectResult HandleValidationFailed(ValidationResponse validation);

    }
    public class BaseMasterManagerGF : IBaseMasterManagerGF
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public BaseMasterManagerGF(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string RequestEmail()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            Claim claim = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            return claim.Value;
        }

        public ObjectResult HandleValidationFailed(ValidationResponse validation)
        {
            var errors = new List<string>();
            errors.Add(validation.ReasonPhrase);
            var errorModel = new ErrorVM(errors, "The request is invalid");

            var result = new ObjectResult(errorModel);

            result.StatusCode = (int?)validation.HttpStatusCode;

            return result;
        }
    }
}
