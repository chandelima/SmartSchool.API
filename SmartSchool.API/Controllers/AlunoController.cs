using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers;
[Route("[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly DataContext _context;

    public AlunoController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Alunos);
    }

    [HttpGet("byId/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
        if (aluno == null) return BadRequest();

        return Ok(aluno);
    }


    [HttpGet("byName")]
    public IActionResult GetByName(
        [FromQuery] string nome,
        [FromQuery] string sobrenome)
    {
        Aluno? aluno = _context.Alunos.FirstOrDefault(a =>
            a.Nome.ToLower().Contains(nome.ToLower()) &&
            a.Sobrenome.ToLower().Contains(sobrenome.ToLower()));

        if (aluno == null) return BadRequest("O aluno não foi encontrado");

        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Aluno aluno)
    {
        if (aluno == null) return BadRequest();
        _context.Alunos.Add(aluno);
        _context.SaveChanges();

        return Ok(aluno);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] Aluno aluno)
    {
        var alunoToPut = _context.Alunos
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);
        var message = "Aluno não encontrado.";
        if (alunoToPut == null) return BadRequest(message);

        _context.Alunos.Update(aluno);
        _context.SaveChanges();

        return Ok(aluno);
    }

    [HttpPatch("{id:int}")]
    public IActionResult Patch(
        [FromRoute] int id,
        [FromBody] Aluno aluno)
    {
        var alunoToPatch = _context.Alunos
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);
        var message = "Aluno não encontrado.";
        if (alunoToPatch == null) return BadRequest(message);

        _context.Alunos.Update(aluno);
        _context.SaveChanges();
        
        return Ok(aluno);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id)
    {
        var alunoToRemove = _context.Alunos.FirstOrDefault(a => a.Id == id);
        var message = "Aluno não encontrado.";
        if (alunoToRemove == null) return BadRequest(message);

        _context.Alunos.Remove(alunoToRemove);
        _context.SaveChanges();

        return Ok();
    }
}
