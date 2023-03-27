using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ProfessorController : ControllerBase
{
    private readonly DataContext _context;

    public ProfessorController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Professores);
    }

    [HttpGet("byId/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
        if (professor == null) return BadRequest("Professor não encontrado");

        return Ok(professor);
    }


    [HttpGet("byName")]
    public IActionResult GetByName(
        [FromQuery] string nome,
        [FromQuery] string sobrenome)
    {
        Professor? professor = _context.Professores.FirstOrDefault(a =>
            a.Nome.ToLower().Contains(nome.ToLower()));

        if (professor == null) return BadRequest("O professor não foi encontrado");

        return Ok(professor);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Professor professor)
    {
        if (professor == null) return BadRequest();
        _context.Professores.Add(professor);
        _context.SaveChanges();

        return Ok(professor);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] Professor professor)
    {
        var professorToPut = _context.Professores
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);
        var message = "Professor não encontrado.";
        if (professorToPut == null) return BadRequest(message);

        _context.Professores.Update(professor);
        _context.SaveChanges();

        return Ok(professor);
    }

    [HttpPatch("{id:int}")]
    public IActionResult Patch(
        [FromRoute] int id,
        [FromBody] Professor professor)
    {
        var professorToPatch = _context.Professores
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);
        var message = "Professor não encontrado.";
        if (professorToPatch == null) return BadRequest(message);

        _context.Professores.Update(professor);
        _context.SaveChanges();

        return Ok(professor);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id)
    {
        var professorToRemove = _context.Professores.FirstOrDefault(a => a.Id == id);
        var message = "Professor não encontrado.";
        if (professorToRemove == null) return BadRequest(message);

        _context.Professores.Remove(professorToRemove);
        _context.SaveChanges();

        return Ok();
    }
}
