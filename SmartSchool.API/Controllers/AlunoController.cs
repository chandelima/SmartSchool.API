using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Runtime.InteropServices;

namespace SmartSchool.API.Controllers;
[Route("[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    public List<Aluno> Alunos = new List<Aluno>()
    {
        new Aluno()
        {
            Id = 1,
            Nome = "Marcos",
            Sobrenome = "Almeida",
            Telefone = "1231312312"
        },
        new Aluno()
        {
            Id = 2,
            Nome = "Marta",
            Sobrenome = "Kent",
            Telefone = "5165465165"
        },
        new Aluno()
        {
            Id = 3,
            Nome = "Laura",
            Sobrenome = "Maria",
            Telefone = "64645189544"
        },
    };
    
    public AlunoController() { }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Alunos);
    }

    [HttpGet("byId/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var aluno = Alunos.FirstOrDefault(a => a.Id == id);
        if (aluno == null) return BadRequest();

        return Ok(aluno);
    }


    [HttpGet("byName")]
    public IActionResult GetByName(
        [FromQuery] string nome,
        [FromQuery] string sobrenome)
    {
        Aluno? aluno = Alunos.FirstOrDefault(a =>
            a.Nome.ToLower().Contains(nome.ToLower()) &&
            a.Sobrenome.ToLower().Contains(sobrenome.ToLower()));

        if (aluno == null) return BadRequest("O aluno não foi encontrado");

        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Aluno aluno)
    {
        if (aluno == null) return BadRequest();
        Alunos.Add(aluno);

        return Ok(aluno);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] Aluno aluno)
    {
        if (aluno == null) return BadRequest();
        Alunos.Add(aluno);

        return Ok(aluno);
    }

    [HttpPatch("{id:int}")]
    public IActionResult Patch(
        [FromRoute] int id,
        [FromBody] Aluno aluno)
    {
        return Ok(aluno);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id)
    {
        var alunoToRemove = Alunos.FirstOrDefault(a => a.Id == id);
        if (alunoToRemove == null) return BadRequest();

        Alunos.Remove(alunoToRemove);

        return Ok();
    }
}
