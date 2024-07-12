using JustinaBack.DAL;
using JustinaBack.Models;
using Microsoft.AspNetCore.Identity;


namespace JustinaBack.BLL
{
    public interface IJwtSecurityManager
    {
        Task<IdentityResult> ChangePasswordAsync(string email, UserManager<UserEF> _userManager, SignInManager<UserEF> signInManager, ChangePasswordRequestVM model);
        Task<JwtLoginResponseVM> LoginAsync(JwtSettings _jwtSettings, UserManager<UserEF> _userManager, SignInManager<UserEF> _signInManager, LoginVM model);
        Task<IdentityResult> RegisterAsync(UserEF user, IUserStore<UserEF> _userStore, IUserEmailStore<UserEF> _emailStore, UserManager<UserEF> _userManager, IUnitOfWork _unitOfWork, RegisterUserVM model);
        Task SaveAsync();

    }
}
