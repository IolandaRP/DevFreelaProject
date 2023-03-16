using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillController(IMediator mediator)
        {
           _mediator= mediator;
        }

        public async Task<IActionResult> Get() 
        {
            var query = new GetAllSkillQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
