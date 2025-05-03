
using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdressController : Controller
    {

        private readonly CafeContext _context;

        public AdressController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Adresses.ToList();
            return View(value);
        }
        public IActionResult AddAdresses()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddAdresses(Adress p)
        {
            _context.Adresses.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteAdresses(int id)
        {
            var value = _context.Adresses.Find(id);
            _context.Adresses.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAdresses(int id)
        {
            var value = _context.Adresses.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAdresses(Adress p)
        {
            _context.Adresses.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
