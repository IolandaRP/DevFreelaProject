using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService= projectService;   
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
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.CreateProject(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        }

        //api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            var project = GetById(inputModel.Id);
            
            if (project == null)
            {
                return NotFound();
            }
          
            _projectService.UpdateProject(inputModel);

            return NoContent();
        }

        //api/projects/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            _projectService.Delete(id);

            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] NewCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            _projectService.Start(id);
            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            var project = GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            _projectService.Finish(id);

            return NoContent();
        }
    }
}
