using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option)
        {

            _option = option.Value;
        }

        //api/projects?query=netcore
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        //api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound();
            return Ok();
        }

        //api/projects
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if(createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            //criar projeto

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);

        }

        //api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            //atualizar projeto

            return NoContent();
        }

        //api/projects/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return NotFound();

            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
