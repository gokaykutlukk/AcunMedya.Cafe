﻿using AcunMedya.Cafe.Context;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly CafeContext db;
        public DashboardController(CafeContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Message=db.Notifications.Select(x => x.Message).FirstOrDefault();
            ViewBag.Title = db.Notifications.Select(x => x.Title).FirstOrDefault();
            ViewBag.SenderName = db.Notifications.Select(x => x.SenderName).FirstOrDefault();
            ViewBag.Created = db.Notifications.Select(x => x.CreatedAt).FirstOrDefault();


            ViewBag.UrunSayisi = db.Products.Count();
            ViewBag.AboneSayisi = db.Subcribes.Count();
            ViewBag.ReferansSayisi = db.Testimonials.Count();
            var subscribers = db.Subcribes.OrderByDescending(x => x.SubcribeId).Take(15).ToList();


            ViewBag.urunler = db.Products.Count();
            ViewBag.kategoriler = db.Categories.Count();
            ViewBag.insanlar = db.Testimonials.Count();
            var categoryData = db.Categories
      .Select(c => new
      {
          CategoryName = c.CategoryName,
          ProductCount = c.Products.Count()
      }).ToList();
            return View(subscribers);
        }
    }
}