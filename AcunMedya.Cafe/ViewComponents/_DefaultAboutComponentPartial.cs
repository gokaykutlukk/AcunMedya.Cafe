using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultAboutComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.ToList();
            return View(value);
        }
    }
}
