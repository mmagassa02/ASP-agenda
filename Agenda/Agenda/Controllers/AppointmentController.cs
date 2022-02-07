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
            IEnumerable<Appointment> appointments = _db.Appointments;
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
                _db.Appointments.Add(appoint);
                _db.SaveChanges();
                TempData["success"] = "Le client a bien été ajouté";
                return RedirectToAction("Index");
        }



        public IActionResult Details()
        {

            ViewData["Brokers"] = _db.Brokers.ToList();
            ViewData["Customers"] = _db.Customers.ToList();
            return View();
        }
    }
}
