using Microsoft.AspNetCore.Identity;
using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Entities.Identity;
using TCCII.Deputados.Core.Interfaces;
using TCCII.Deputados.Core.Interfaces.Repositories;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;

namespace TCCII.Deputados.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserServices(
            IUnitOfWork uow,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;            
            _uow = uow;
        }

        public async Task<IdentityResult> CreateUser(User user, string password) =>
            await _userManager.CreateAsync(user, password);

        public async Task<bool> SingInAccontUser(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            return result.Succeeded;
        }

        public async Task<IdentityResult> AddToRole(User user, string role) =>
            await _userManager.AddToRoleAsync(user, role);

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return null;
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return null;
            return user;
        }

        public async Task<IdentityResult> ChangePassword(User user, string password, string newPassWord)
        {
            var result = await _userManager.ChangePasswordAsync(user, password, newPassWord);
            return result;
        }

        public async Task<bool> CheckPasswordUser(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUser(User user)
        {
            try
            {
                return await _userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<string> GenerateResetPasswordToken(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> VerifyTokenForgetPassword(User user, string token)
        {
            return await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "ResetPassword", token);
        }

        public async Task<IdentityResult> ResetPassword(User user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public List<Deputado> GetFollowDeputados(User user)
        {
            var userDeputados = _uow.UserDeputadosRepository.QueryableFor(x => x.UserId == user.Id).ToList();
            var listDeputados = new List<Deputado>();
            foreach (var deputado in userDeputados)
                listDeputados.Add(_uow.DeputadosRepository.FindById(deputado.DeputadosId));
            return listDeputados;
        }
    }
}
