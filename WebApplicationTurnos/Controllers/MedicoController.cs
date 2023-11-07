using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTurnos.Models;

namespace WebApplicationTurnos.Controllers
{
    public class MedicoController : Controller
    {
        private readonly TurnosContext _context;

        public MedicoController(TurnosContext context)
        {
            _context = context;
        }

        // GET: Medico

        public async Task<IActionResult> Index()
        {
              return _context.Medico != null ? 
                          View(await _context.Medico.ToListAsync()) :
                          Problem("Entity set 'TurnosContext.Medico'  is null.");
        }

        // GET: Medico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Where(m => m.Id == id).Include(me => me.MedicoEspecialidad)
                .ThenInclude(e => e.EspecialidadNavigation).FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medico/Create
        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad, "Id", "Descripcion");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,Telefono,Email,HorarioAtencionDesde,HorarioAtencionHasta")] Medico medico, int IdEspecialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();

                var medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = medico.Id;
                medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                _context.Add(medicoEspecialidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            //var medico = await _context.Medico.FindAsync(id);

            //Cruzamos datos con tabla Especialidad con un InnerJoin(Include)
            var medico = await _context.Medico.Where(m => m.Id == id)
                .Include(me => me.MedicoEspecialidad).FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }

            ViewData["ListaEspecialidades"] = new SelectList(
                //Todos los registros // id asociado a cada value // campo a mostrar en listbox // valor seleccionado por default
                _context.Especialidad, "Id", "Descripcion", medico.MedicoEspecialidad[0].IdEspecialidad
                );

            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Direccion,Telefono,Email,HorarioAtencionDesde,HorarioAtencionHasta")] Medico medico, int IdEspecialidad)
        {
            if (id != medico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();

                    //valor como default
                    var medicoEspecialidad = await _context.MedicoEspecialidad
                        .FirstOrDefaultAsync(me => me.IdMedico == id);

                    if(medicoEspecialidad  == null)
                    {
                        return NotFound();
                    }
                    _context.Remove(medicoEspecialidad);
                    await _context.SaveChangesAsync();

                    medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                    _context.Add(medicoEspecialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicoEspecialidad = await _context.MedicoEspecialidad
                .FirstOrDefaultAsync(me => me.IdMedico == id);

            if (medicoEspecialidad == null)
            {
                return NotFound();
            }
            _context.MedicoEspecialidad.Remove(medicoEspecialidad);
            await _context.SaveChangesAsync();

            if (_context.Medico == null)
            {
                return Problem("Entity set 'TurnosContext.Medico'  is null.");
            }
            var medico = await _context.Medico.FindAsync(id);
            if (medico != null)
            {
                _context.Medico.Remove(medico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
          return (_context.Medico?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public string TraerHorarioAtencionDesde(int idMedico)
        {
            //creamos la propiedad, buscamos por el id que traemos y asignamos a la variable crada
            var HorarioAtencionDesde = _context.Medico.Where(m => m.Id == idMedico).FirstOrDefault();
            if(HorarioAtencionDesde == null)
            {
                return "05:00";
            }
            return HorarioAtencionDesde.HorarioAtencionDesde.Hour + ":" + HorarioAtencionDesde.HorarioAtencionDesde.Minute;
        }

        public string TraerHorarioAtencionHasta(int idMedico)
        {
            //creamos la propiedad, buscamos por el id que traemos y asignamos a la variable crada
            var HorarioAtencionHasta = _context.Medico.Where(m => m.Id == idMedico).FirstOrDefault();
            if (HorarioAtencionHasta == null)
            {
                return "15:00";
            }
            return HorarioAtencionHasta.HorarioAtencionHasta.Hour + ":" + HorarioAtencionHasta.HorarioAtencionHasta.Minute;
        }
    }
}
