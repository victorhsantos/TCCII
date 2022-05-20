using Microsoft.AspNetCore.Identity;
using TCCII.Deputados.Core.Entities;
using TCCII.Deputados.Core.Entities.Identity;

namespace TCCII.Deputados.Core.Interfaces
{
    public interface IUserServices
    {
        Task<IdentityResult> CreateUser(User user, string password);
        Task<bool> SingInAccontUser(string userName, string password);
        Task<IdentityResult> AddToRole(User user, string role);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUserName(string userName);
        Task<IdentityResult> ChangePassword(User user, string password, string newPassword);
        Task<bool> CheckPasswordUser(User user, string password);
        Task<IdentityResult> UpdateUser(User user);
        Task<string> GenerateResetPasswordToken(User user);
        Task<bool> VerifyTokenForgetPassword(User user, string token);
        Task<IdentityResult> ResetPassword(User user, string token, string newPassword);
        List<Deputado> GetFollowDeputados(User user);
    }
}
