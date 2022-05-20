using AutoMapper;
using TCCII.Deputados.API.DTOs.RequestModels.Account;
using TCCII.Deputados.API.Models;
using TCCII.Deputados.Core.Entities.Identity;

namespace TCCII.Deputados.API.Profiles
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
