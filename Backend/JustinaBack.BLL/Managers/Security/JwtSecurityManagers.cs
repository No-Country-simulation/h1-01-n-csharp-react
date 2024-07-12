using JustinaBack.DAL;
using JustinaBack.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace JustinaBack.BLL
{
    public class JwtSecurityManager : IJwtSecurityManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public JwtSecurityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IdentityResult> ChangePasswordAsync(string email, UserManager<UserEF> _userManager, SignInManager<UserEF> signInManager, ChangePasswordRequestVM model)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.ChangePasswordAsync(user!, model.CurrentPassword!, model.NewPassword!);
        }

        public async Task<JwtLoginResponseVM> LoginAsync(JwtSettings _jwtSettings, UserManager<UserEF> _userManager, SignInManager<UserEF> _signInManager, LoginVM model)
        {
            var response = new JwtLoginResponseVM();

            UserEF user = new UserEF
            {
                UserName = model.Username,
            };

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(model.Username);
                if (currentUser!.DeletedBy == null || currentUser.DeletedBy == 0)
                {
                    var token = new UserToken();

                    var roles = await _userManager.GetRolesAsync(currentUser);
                    var claims = new List<Claim>();

                    claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

                    token = JwtHelper.GenTokenkey(new UserToken
                    {
                        EmailId = currentUser.Email!,
                        GuidId = Guid.NewGuid(),
                        UserName = currentUser.UserName!,
                        Id = Convert.ToUInt16(currentUser.Id),
                    }, _jwtSettings, claims);

                    response.Token = token;
                    response.Success = result.Succeeded;
                    return response;
                }
                response.Success = false;
            }
            return response;
        }

        public async Task<IdentityResult> RegisterAsync(UserEF user, IUserStore<UserEF> _userStore, IUserEmailStore<UserEF> _emailStore, UserManager<UserEF> _userManager, IUnitOfWork _unitOfWork, RegisterUserVM model)
        {
            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);

            var contact = model.GetContact();

            var address = model.GetAddress();

            if (address is not null)
            {
                contact.Addresses = new List<AddressEF> { address };
            }

            var phone = model.GetPhone();

            contact.Phones = new List<PhoneEF> { phone };

            user.Contact = contact;

            return await _userManager.CreateAsync(user, model.Password!);
        }

        public async Task SaveAsync()
        {
            await _unitOfWork!.SaveAsync();
        }
    }
}
