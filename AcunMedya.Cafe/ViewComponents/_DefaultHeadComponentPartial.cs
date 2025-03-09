using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

// önce views e gidiyor sonra components e gidiyor sonra viewcomponents e gidiyor
