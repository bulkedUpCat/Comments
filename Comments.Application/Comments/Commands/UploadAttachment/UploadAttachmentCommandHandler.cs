using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Comments.Application.Exceptions;
using MediatR;

namespace Comments.Application.Comments.Commands.UploadAttachment
{
    public class UploadAttachmentCommandHandler: IRequestHandler<UploadAttachmentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStorageService _storageService;
        private readonly ICommentsDbContext _context;

        public UploadAttachmentCommandHandler(
            ICommentRepository commentRepository,
            IStorageService storageService,
            ICommentsDbContext context)
        {
            _commentRepository = commentRepository;
            _storageService = storageService;
            _context = context;
        }

        public async Task Handle(UploadAttachmentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id, cancellationToken)
                          ?? throw new CommentNotFoundException(request.Id);

            await _storageService
                .UploadFileAsync(request.File, "comments", comment.Id.ToString(), cancellationToken);

            comment.HasAttachment = true;
            
            _commentRepository.Update(comment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}