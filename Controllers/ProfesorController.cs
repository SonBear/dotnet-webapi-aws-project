using entrega1.Models;
using entrega1.Services;
using Microsoft.AspNetCore.Mvc;

namespace entrega1.Controllers;

[ApiController]
[Route("profesores")]
public class ProfesorController : ControllerBase
{
    public ProfesorController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Profesor>> GetAll() =>
        ProfesorService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Profesor> Get(int id)
    {
        var Profesor = ProfesorService.Get(id);

        if (Profesor == null)
            return NotFound();

        return Profesor;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Profesor Profesor)
    {
        ProfesorService.Add(Profesor);
        return CreatedAtAction(nameof(Create), new { id = Profesor.Id }, Profesor);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Profesor Profesor)
    {
        if (id != Profesor.Id)
            return BadRequest();

        var existingProfesor = ProfesorService.Get(id);
        if (existingProfesor is null)
            return NotFound();

        ProfesorService.Update(Profesor);

        return Ok(existingProfesor);
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Profesor = ProfesorService.Get(id);

        if (Profesor is null)
            return NotFound();

        ProfesorService.Delete(id);

        return Ok(Profesor);
    }
}