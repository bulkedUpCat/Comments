﻿using AutoMapper;
using Comments.Application.Comments.Commands.CreateComment;
using Comments.Application.Models.Comment;
using Comments.Domain.Entities;

namespace Comments.Application.Common.Profiles
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(dest => dest.CreatedAt, src => src.MapFrom(opt => opt.CreatedAt));
                
            CreateMap<CreateCommentCommand, Comment>();
        }
    }
}