using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> ListaPizze = db.Pizze.ToList<Pizza>();

                return View("Index", ListaPizze);
            }

        }
        public IActionResult Dettagli(int ID)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizza =
                    (from pi in db.Pizze
                     where pi.Id == ID
                     select pi).FirstOrDefault();
                if (pizza != null)
                {
                    return View(pizza);
                }
                else
                {
                    return NotFound("La pizza ricercata non è presente a listino");
                }

            }
        }

        [HttpGet]
        public IActionResult NuovaPizza()
        {
            return View("NuovaPizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuovaPizza(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("NuovaPizza", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                db.Pizze.Add(formData);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int ID)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizza =
                    (from pi in db.Pizze
                     where pi.Id == ID
                     select pi).FirstOrDefault();
                if (pizza != null)
                {
                    return View("ModificaPizza", pizza);
                }
                else
                {
                    return NotFound("La pizza ricercata non è presente a listino");
                }

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificaPizza(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("ModificaPizza", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzadamodificare = (from pi in db.Pizze
                                           where pi.Id == formData.Id
                                           select pi).FirstOrDefault();
                if (pizzadamodificare != null)
                {
                    pizzadamodificare.nome = formData.nome;
                    pizzadamodificare.descrizione = formData.descrizione;
                    pizzadamodificare.immagine = formData.immagine;
                    pizzadamodificare.prezzo = formData.prezzo;

                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }

        public IActionResult EliminaPizza(int ID)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzadaEliminare = (from pi in db.Pizze
                                           where pi.Id == ID
                                           select pi).FirstOrDefault();
                if (pizzadaEliminare != null)
                {
                    db.Remove(pizzadaEliminare);

                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }
    }
}

