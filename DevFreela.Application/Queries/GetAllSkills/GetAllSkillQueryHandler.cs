using Dapper;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.ViewModels;
using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using DevFreela.Instrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillQueryHandler(ISkillRepository skillRepository)
        {
           _skillRepository = skillRepository;
        }
        public async Task<List<SkillDTO>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllAsync();
        }
    }
}
