using JustinaBack.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Net;
using System.Security.Claims;


namespace JustinaBack.BLL
{
    public class BaseManagerGF
    {
        //internal readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _httpContextAccessor;        

        public BaseManagerGF(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }     

        public string RequestEmail()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            Claim claim = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            return claim.Value;
        }

        #region Business Logic
        public HttpResponseMessage? Empty<T>(T item)
        {
            HttpResponseMessage? response = null;
            if (item == null)
            {
                response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = "Something went wrong! - EO";
            }
            return response;
        }

        public ValidationResponse Validate(List<HttpResponseMessage> responseMessages)
        {
            var validation = new ValidationResponse();
            foreach (var item in responseMessages)
            {
                if (item != null)
                {
                    validation.Failed = true;
                    validation.HttpStatusCode = item.StatusCode;
                    validation.ReasonPhrase = item.ReasonPhrase;
                }
                if (validation.Failed)
                    return validation;
            }
            return validation;
        }

        public BusinessResponse GetBusinessResponse(HttpStatusCode statusCode)
        {
            return new BusinessResponse
            {
                StatusCode = statusCode,
            };
        }

        public BusinessResponse GetBusinessResponse(HttpStatusCode statusCode, string message)
        {
            return new BusinessResponse
            {
                StatusCode = statusCode,
                Message = message,
            };
        }

        public BusinessResponse GetBusinessResponse(HttpStatusCode statusCode, string? publicKey, object? genericObject, IEnumerable? genericList)
        {
            return new BusinessResponse
            {
                StatusCode = statusCode,
                PublicKey = publicKey,
                GenericObject = genericObject,
                GenericList = genericList,
            };
        }
        #endregion
    }
}
