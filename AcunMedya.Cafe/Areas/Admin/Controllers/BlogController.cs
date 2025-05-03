using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly CafeContext _context;

        public BlogController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Blogs.ToList();
            return View(value);
        }
        public IActionResult AddBlog()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {

            _context.Blogs.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteBlog(int id)
        {
            var value = _context.Blogs.Find(id);
            _context.Blogs.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult UpdateBlog(int id)
        {
            var value = _context.Blogs.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog p)
        {
            _context.Blogs.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}