using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly CafeContext _context;

        public NotificationController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notifications = _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
            return View(notifications);
        }
    }
}
