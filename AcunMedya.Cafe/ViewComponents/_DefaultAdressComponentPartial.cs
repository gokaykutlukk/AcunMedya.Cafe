using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultAdressComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultAdressComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Adresses.ToList();
            return View(value);
        }
    }
}
