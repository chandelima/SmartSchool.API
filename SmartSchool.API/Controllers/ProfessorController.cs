using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ProfessorController : ControllerBase
{
    public ProfessorController() { }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Professores: Marta, Paula, Lucas, Rafa");
    }
}
