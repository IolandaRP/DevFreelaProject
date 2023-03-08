using Azure.Core;
using DevFreela.Instrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    internal class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public FinishProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            if (project != null)
            {
                project.Finish();
            }

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
