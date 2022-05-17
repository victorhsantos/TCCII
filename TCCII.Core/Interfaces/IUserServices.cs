using Microsoft.AspNetCore.Identity;
using TCCII.Core.Entities.Identity;

namespace TCCII.Core.Interfaces
{
    public interface IUserServices
    {
        Task<IdentityResult> CreateUser(User user, string password);
        Task<bool> SingInAccontUser(string userName, string password);
        Task<IdentityResult> AddToRole(User user, string role);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUserName(string userName);
        Task<IdentityResult> ChangePassword(User user, string password, string newPassWord);
        Task<bool> CheckPasswordUser(User user, string password);
        Task<IdentityResult> UpdateUser(User user);
        Task<string> GenerateResetPasswordToken(User user);
        Task<bool> VerifyTokenForgetPassword(User user, string token);
        Task<IdentityResult> ResetPassword(User user, string token, string newPassword);
    }
}
