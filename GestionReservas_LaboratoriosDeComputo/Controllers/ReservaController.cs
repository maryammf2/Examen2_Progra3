using GestionReservas_LaboratoriosDeComputo.Data;
using GestionReservas_LaboratoriosDeComputo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionReservas_LaboratoriosDeComputo.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaRepository _repositorio;

        public ReservaController(ReservaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            var reservas = _repositorio.ObtenerTodas();
            return View(reservas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            if (reserva.FechaReserva.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("FechaReserva", "La fecha no puede ser en el pasado.");
            }
            if (reserva.HoraInicio >= reserva.HoraFin)
            {
                ModelState.AddModelError("HoraFin", "La hora de fin debe ser mayor que la hora de inicio.");
            }

            if (_repositorio.CodigoExiste(reserva.Codigo))
            {
                ModelState.AddModelError("Codigo", "Ya existe una reserva con este código.");
            }
            if (!ModelState.IsValid)
            {
                return View(reserva);
            }
            _repositorio.Agregar(reserva);

            TempData["MensajeExito"] = "Reserva registrada exitosamente.";

            return RedirectToAction(nameof(Index));
        }

    } //class
} //end
