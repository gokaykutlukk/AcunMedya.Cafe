using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly CafeContext _context;

        public AboutController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Abouts.ToList();
            return View(value);
        }
        public IActionResult AddAbout()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Abouts.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About p)
        {
            _context.Abouts.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}