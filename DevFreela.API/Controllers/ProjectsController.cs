using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        { 
            _mediator= mediator;
        }

        //api/projects?query=netcore
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        //api/projects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if(project == null)
            {
                return NotFound();
            }
           
            return Ok(project);
        }

        //api/projects
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectCommand command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }

        //api/projects/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            var project = GetById(command.Id);
            
            if (project == null)
            {
                return NotFound();
            }

            _mediator.Send(command);

            return NoContent();
        }

        //api/projects/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            var project = GetById(command.Id);

            if (project == null)
            {
                return NotFound();
            }

            _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
           await _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var command = new StartProjectCommand(id);

            var project = GetById(command.Id);

            if (project == null)
            {
                return NotFound();
            }

            _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            var project = GetById(command.Id);

            if (project == null)
            {
                return NotFound();
            }

            _mediator.Send(command);

            return NoContent();
        }
    }
}
