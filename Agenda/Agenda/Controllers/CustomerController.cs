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

        public IActionResult Add()
        {
            return View();
        }


        //Add Customer
        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Add(Customer custom)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(custom); //1 prépare l'objet
                _db.SaveChanges(); // sauvegarde bdd
                TempData["success"] = "Le client a bien été ajouté";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Edit Customer

        public IActionResult Edit(int? id)
        {
            var custom = _db.Customers.Find(id);
            if (custom == null)
            {
                return NotFound();
            }

            return View(custom);
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Edit(Customer custom)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(custom);
                _db.SaveChanges();
                TempData["success"] = "Client modifié";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Details(int? id)
        {
            var custom = _db.Customers.Find(id);
            if (custom == null)
            {
                return NotFound();
            }

            return View(custom);
        }

        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken] // Attaque de typre cross-site
        public IActionResult Remove(Customer custom)
        {
            _db.Customers.Remove(custom);
            _db.SaveChanges();

            TempData["success"] = "Le client a bien été supprimé";

            return RedirectToAction("Index");
        }

    }
}
