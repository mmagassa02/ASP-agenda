using Microsoft.AspNetCore.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class BrokerController : Controller
    {
        private readonly agendaContext _db;
        public BrokerController(agendaContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Broker> Brokers = _db.Brokers.OrderBy(Broker => Broker.Lastname);
            return View(Brokers);
        }

        public IActionResult Add()
        {
            return View();
        }


        //Add broker
        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Add(Broker brok)
        {
            if (ModelState.IsValid)
            {
                _db.Brokers.Add(brok); //1 prépare l'objet
                _db.SaveChanges(); // sauvegarde bdd
                TempData["success"] = "Le courtier a bien été ajouté";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Edit Broker

        public IActionResult Edit(int? id)
        {
            var brok = _db.Brokers.Find(id);
            if (brok == null)
            {
                return NotFound();
            }

            return View(brok);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Edit(Broker brok, int id)
        {
            if (ModelState.IsValid)
            {
                brok.IdBroker= id;
                _db.Brokers.Update(brok); //1 prépare l'objet
                _db.SaveChanges(); // sauvegarde bdd
                TempData["success"] = "Le courtier a bien été modifié";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Details(int? id)
        {
            var brok = _db.Brokers.Find(id);
            if (brok == null)
            {
                return NotFound();
            }

            return View(brok);
        }


    }
}
