using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultBlogComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultBlogComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Blogs.ToList();
            return View(value);
        }
    }
}
