namespace Comments.Application.Models.Comment
{
    public class CommentFilterModel
    {
        public string? Sort { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; } = 1;
        public int PageCount { get; set; } = 25;
    }
}