using Microsoft.AspNetCore.Mvc;
using Agenda.Models;


namespace Agenda.Controllers
{
    public class CustomerController : Controller
    {
        private readonly agendaContext _db;

        public CustomerController(agendaContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> customers = _db.Customers;
            return View(customers);
        }

        //Add broker
        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Add(Customer custom)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(custom); //1 prépare l'objet
                _db.SaveChanges(); // sauvegarde bdd
                TempData["success"] = "L'article a bien été ajouté";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Edit Broker
        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Edit(Customer custom)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(custom);
                _db.SaveChanges();
                TempData["success"] = "Customer modifié";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
