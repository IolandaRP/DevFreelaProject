using Dapper;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.ViewModels;
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
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillViewModel>>
    {
        private readonly string _connectionString;
        public GetAllSkillQueryHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "Select Id, Description from Skills";

                var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);

                return skills.ToList()  ;
            }
        }
    }
}
