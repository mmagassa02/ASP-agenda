using Microsoft.AspNetCore.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly agendaContext _db;
        public AppointmentController(agendaContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData["Brokers"] = _db.Brokers.ToList();
            ViewData["Customers"] = _db.Customers.ToList();
            IEnumerable<Appointment> appointments = _db.Appointments.OrderBy(Appointment => Appointment.DateHour);
            return View(appointments);
        }


        public IActionResult Add()
        {
            ViewData["Brokers"] = _db.Brokers.ToList();
            ViewData["Customers"] = _db.Customers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Appointment appoint)
        {
            if (!ModelState.IsValid)
            {
                _db.Appointments.Add(appoint);
                _db.SaveChanges();
                TempData["success"] = "Le client a bien été ajouté";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Details rdv
        public IActionResult Details(int? id)
        {

            ViewData["Brokers"] = _db.Brokers.ToList();
            ViewData["Customers"] = _db.Customers.ToList();
            var brok = _db.Appointments.Find(id);
            if (brok == null)
                return NotFound();
            return View(brok);
        }


        public IActionResult Remove(int? id)
        {

            ViewData["Brokers"] = _db.Brokers.ToList();
            ViewData["Customers"] = _db.Customers.ToList();
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            var appoint = _db.Appointments.Find(id);

            if (appoint == null)
            {
                return NotFound();
            }
            return View(appoint);
        }


        [HttpPost]
        public IActionResult Remove(Appointment appoint, int id)
        {
            appoint.IdAppointment = id;
            _db.Appointments.Remove(appoint);
            _db.SaveChanges();

            TempData["success"] = "Le client a bien été supprimé";

            return RedirectToAction("Index");
        }

    }
}
