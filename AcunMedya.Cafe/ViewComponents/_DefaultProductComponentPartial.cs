using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultProductComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultProductComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var values = _context.Products.Include(x => x.Category).ToList();
            return View(values);
        }

    }
}
