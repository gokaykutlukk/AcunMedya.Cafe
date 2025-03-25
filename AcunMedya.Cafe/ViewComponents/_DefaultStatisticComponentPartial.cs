using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultStatisticComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.ProductCount = _context.Products.Count();
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.FeatureCount = _context.Features.Count();
            ViewBag.TestimonialCount = _context.Testimonials.Count();
            return View();
        }
    }

    }
