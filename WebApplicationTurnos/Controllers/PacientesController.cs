using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTurnos.Models;

namespace WebApplicationTurnos.Controllers
{
    public class PacientesController : Controller
    {
        private readonly TurnosContext context;

        public PacientesController(TurnosContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Pacientes.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var paciente = await context.Pacientes.FirstOrDefaultAsync(
                            p => p.Id == id);

            if( paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,Telefono,Email")] Pacientes paciente)
        {
            if (ModelState.IsValid)
            {
                context.Add(paciente);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Direccion,Telefono,Email")] Pacientes paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                context.Add(paciente);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await context.Pacientes.FirstOrDefaultAsync(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]//Delete va a ser el nombre con el que lo llamemos en la vista
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id) 
        { 
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            context.Pacientes.Remove(paciente);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
