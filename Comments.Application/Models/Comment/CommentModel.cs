﻿using System;
using System.Collections.Generic;

namespace Comments.Application.Models.Comment
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Text { get; set; }
        public IEnumerable<CommentModel> Replies { get; set; }
    }
}