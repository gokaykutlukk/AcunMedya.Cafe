using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultTestimonialComponent : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultTestimonialComponent(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var values = _context.Testimonials.ToList();
            return View(values);
        }

    }
}
