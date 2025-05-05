using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {

        private readonly CafeContext _context;

        public TestimonialController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Testimonials.ToList();
            return View(value);
        }
        public IActionResult AddTestimonial()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Testimonials.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial p)
        {
            _context.Testimonials.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
