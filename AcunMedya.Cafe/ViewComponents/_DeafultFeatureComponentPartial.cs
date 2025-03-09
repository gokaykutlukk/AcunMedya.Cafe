using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DeafultFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
