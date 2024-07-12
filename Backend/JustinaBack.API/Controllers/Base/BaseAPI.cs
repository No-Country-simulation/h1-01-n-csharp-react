using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JustinaBack.API.Controllers;
    public class BaseAPI : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public string RequestEmail(ClaimsPrincipal user)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.Email);

        return claim.Value;
    }
}

