using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationTurnos.Models;

namespace WebApplicationTurnos.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnosContext _context;

        public TurnoController(TurnosContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in _context.Medico.ToList() 
                                                   select new { IdMedico = medico.Id, NombreCompleto = medico.Nombre + " " + medico.Apellido}),
                                                   "IdMedico", "NombreCompleto");

            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Pacientes.ToList()
                                                   select new { IdPaciente = paciente.Id, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }),
                                                   "IdPaciente", "NombreCompleto");
            return View();
        }

        public JsonResult ObtenerTurnos(int idMedico)
        {
            var turnos = _context.Turno.Where(t => t.IdMedico == idMedico)
                .Select(t => new
                {
                    t.IdTurno,
                    t.IdMedico,
                    t.IdPaciente,
                    t.FechaHoraInicio,
                    t.FechaHoraFin,
                    paciente = t.PacientesNavigation.Nombre + ", " + t.PacientesNavigation.Apellido
                }).ToList();

            return Json(turnos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GrabarTurno(Turno turno)
        {
            bool ok = false;

            try
            {
                _context.Turno.Add(turno);
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exepcion encontrada", ex);
            }

            var jsonResult = new {ok = ok};

            return Json(jsonResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;

            try
            {
                var turnoEliminar = _context.Turno.Where(t => t.IdTurno == idTurno).FirstOrDefault();
                
                if(turnoEliminar != null)
                {
                    _context.Turno.Remove(turnoEliminar);
                    _context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exepcion encontrada", ex);
            }

            var jsonResult = new { ok = ok };

            return Json(jsonResult);
        }
    }
}
