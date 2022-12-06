using entrega1.Models;
using entrega1.Services;
using Microsoft.AspNetCore.Mvc;

namespace entrega1.Controllers;

[ApiController]
[Route("alumnos")]
public class AlumnoController : ControllerBase
{
    public AlumnoController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Alumno>> GetAll() =>
        AlumnoService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Alumno> Get(int id)
    {
        var Alumno = AlumnoService.Get(id);

        if (Alumno == null)
            return NotFound();

        return Alumno;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Alumno Alumno)
    {
        AlumnoService.Add(Alumno);
        return CreatedAtAction(nameof(Create), new { id = Alumno.Id }, Alumno);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Alumno Alumno)
    {
        var existingAlumno = AlumnoService.Get(id);
        if (existingAlumno is null)
            return NotFound();

        return Ok(AlumnoService.Update(existingAlumno, Alumno));
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Alumno = AlumnoService.Get(id);

        if (Alumno is null)
            return NotFound();

        AlumnoService.Delete(id);

        return Ok(Alumno);
    }
}