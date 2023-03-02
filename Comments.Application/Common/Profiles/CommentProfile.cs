using AutoMapper;
using Comments.Application.Comments.Commands.CreateComment;
using Comments.Application.Comments.Queries.GetAllComments;
using Comments.Application.Models.Comment;
using Comments.Domain.Entities;

namespace Comments.Application.Common.Profiles
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(dest => dest.CreatedAt, src => src.MapFrom(opt => opt.CreatedAt))
                .ForMember(dest => dest.Email, src => src.MapFrom(opt => opt.User.Email))
                .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.User.UserName))
                .ForMember(dest => dest.UserId, src => src.MapFrom(opt => opt.UserId));
                
            CreateMap<CreateCommentCommand, Comment>();

            CreateMap<GetAllCommentsQuery, CommentFilterModel>();
        }
    }
}