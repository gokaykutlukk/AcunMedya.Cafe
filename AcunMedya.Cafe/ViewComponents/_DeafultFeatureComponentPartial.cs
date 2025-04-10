﻿using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DeafultFeatureComponentPartial:ViewComponent
    {
        private readonly CafeContext _context;

        public _DeafultFeatureComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Features.ToList();
            ViewBag.Subtitle = _context.Features.Select(x => x.SubTitle).FirstOrDefault();
            return View(values);
        }
    }
}
