using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService= projectService;   
            _mediator= mediator;
        }

        //api/projects?query=netcore
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        //api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

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
            if(command.Title.Length > 50)
            {
                return BadRequest();
            }

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
