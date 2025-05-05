using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;
        public _AdminLayoutNavbarComponentPartial(CafeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {


            ViewBag.UnreadNotificationCount = _context.Notifications.Where(x => x.IsRead == false).Count();
            ViewBag.LastNotifications = _context.Notifications.OrderByDescending(x => x.NotificationId).Take(3).ToList();
            return View();
        }
    }
}