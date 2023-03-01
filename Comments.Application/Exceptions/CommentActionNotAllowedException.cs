namespace Comments.Application.Exceptions
{
    public class CommentActionNotAllowedException: BadRequestException
    {
        public CommentActionNotAllowedException(string message): base(message){}
    }
}