using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTurnos.Models;

namespace WebApplicationTurnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext context;

        public EspecialidadController(TurnosContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View( await context.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var especialidad = await context.Especialidad.FindAsync(id);

            if(especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost] //Diferencia el metodo Edit que graba del de vista
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Especialidad especialidad)
        {
            if(id != especialidad.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                context.Update(especialidad);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var especialidad = await context.Especialidad.FirstOrDefaultAsync(e => e.Id == id);

            if(especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (int id)
        {
            var especialidad = await context.Especialidad.FindAsync(id);
            if(especialidad == null) 
            { 
                return NotFound(); 
            }
            context.Especialidad.Remove(especialidad);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id","Descripcion")] Especialidad especialidad)
        {
            if(ModelState.IsValid)
            {
                context.Add(especialidad);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
