using DevFreela.Core.Entities;
using DevFreela.Instrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.IdProject);

            if (project != null)
            {
                var comment = new ProjectComments(request.Content, request.IdProject, request.IdUser);

                await _dbContext.Comments.AddAsync(comment);

                await _dbContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
