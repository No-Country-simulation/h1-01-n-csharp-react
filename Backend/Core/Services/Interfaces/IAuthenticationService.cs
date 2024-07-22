using DTOs.Auth;
using DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterMedicAsync(RegisterMedicRequest request);
        Task<RegisterResponse> RegisterPatientAsync(RegisterPatientRequest request);
    }
}
