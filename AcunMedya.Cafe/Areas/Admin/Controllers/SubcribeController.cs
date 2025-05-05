using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{

    public class SubcribeController : Controller
    {


       
        private readonly CafeContext _context;

        public SubcribeController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Subcribes.ToList();
            return View(value);
        }
        public IActionResult AddSubscries()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSubscribes(Subcribe p)
        {
            _context.Subcribes.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteSubscribes(int id)
        {
            var value = _context.Subcribes.Find(id);
            _context.Subcribes.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSubscribes(int id)
        {
            var value = _context.Subcribes.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSubscribes(Subcribe p)
        {
            _context.Subcribes.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
