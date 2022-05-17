using AutoMapper;
using TCCII.API.Authentication.API.DTOs.RequestModels.Account;
using TCCII.API.Authentication.API.Models;
using TCCII.Core.Entities.Identity;

namespace TCCII.API.Authentication.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, UserModel>();                
            CreateMap<UserModel, User>();            
        }
    }
}
