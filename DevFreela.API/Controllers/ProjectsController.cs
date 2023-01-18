using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
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
    }
}
