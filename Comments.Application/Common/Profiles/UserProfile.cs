using AutoMapper;
using Comments.Application.Models.User;
using Comments.Domain.Entities;

namespace Comments.Application.Common.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}