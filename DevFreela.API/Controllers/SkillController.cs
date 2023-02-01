using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
           _skillService= skillService;
        }

        public IActionResult Get() 
        {
            var skillViewModel = _skillService.GetAll();

            return Ok(skillViewModel);
        }
    }
}
