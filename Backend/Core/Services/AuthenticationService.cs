using Core.Services.Interfaces;
using Domain.Entities.Users;
using DTOs.Auth;
using DTOs.Register;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMedicRepository _medicRepository;

        public AuthenticationService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IUserRepository userRepository,
            IMedicRepository medicRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userRepository = userRepository;
            _medicRepository = medicRepository;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new Exception($"Usuario con email '{request.Email}' no encontrado.");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
                throw new Exception($"Las credenciales para el email '{request.Email}' no son válidas");

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            };

            return response;
        }

        public async Task<RegisterResponse> RegisterMedicAsync(RegisterMedicRequest request)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                EmailConfirmed = true,
                UserName = request.Email,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Medic = new Medic
                {
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    DNI = request.DNI,
                    License = request.License,
                    SpecialtyId = request.SpecialtyId,
                    ImgSrc = request.ImgSrc,
                }
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            //Verify if an account is already using the DNI received
            var existingDNI = await _userRepository.IsDNIInUse(request.DNI);
            if (existingDNI) throw new Exception("El DNI ingresado ya esta en uso.");

            //Verify if an account is already using the License received
            var existingLicense = await _medicRepository.FindLicenseInMedics(request.License);
            if (existingLicense) throw new Exception("La licencia médica ingresada ya esta en uso.");

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    //Assign role           
                    await _userManager.AddToRoleAsync(user, request.UserType.ToString());

                    // Generate Token
                    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                    return new RegisterResponse()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"El email '{request.Email}' ya existe.");
            }
        }

        public async Task<RegisterResponse> RegisterPatientAsync(RegisterPatientRequest request)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                EmailConfirmed = true,
                UserName = request.Email,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Patient = new Patient
                {
                    FirstName =  request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    DNI = request.DNI,
                    BirthDate = request.BirthDate,
                    IsManagedByParent = request.IsManagedByParent,
                    ParentName = request.IsManagedByParent ? request.ParentName : "",
                    BloodType = request.BloodType,
                    ImgSrc = request.ImgSrc,
                }
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            //Verify if an account is already using the DNI received
            var existingDNI = await _userRepository.IsDNIInUse(request.DNI);
            if (existingDNI) throw new Exception("El DNI ingresado ya esta en uso.");

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    //Assign role           
                    await _userManager.AddToRoleAsync(user, request.UserType.ToString());

                    // Generate Token
                    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                    return new RegisterResponse()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"El email '{request.Email}' ya existe.");
            }
        }

        public async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            IEnumerable<Claim> claims = new[]
            {
                new Claim("id", user.Id.ToString()),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(int.Parse(_configuration["JwtSettings:DurationInDays"])),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
