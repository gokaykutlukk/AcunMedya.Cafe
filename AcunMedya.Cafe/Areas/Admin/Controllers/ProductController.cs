using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly CafeContext _context;

        public ProductController(CafeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString(),
                                           }
                                     ).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {

            if (p.ImageFile != null)
            {
                //uygulamanın çalıştığ dizi al
                var currentDirectory = Directory.GetCurrentDirectory();
                //uygulamanın uzantısını al
                var extension = Path.GetExtension(p.ImageFile.FileName);
                // benzersiz bir dosya adı oluştur
                var filename = Guid.NewGuid().ToString();
                //kayıt edilecek dosyanın yolu
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images", filename + extension);
                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);
                //dosyayı fiziksel olarak sunucuya yazar
                p.ImageFile.CopyTo(stream);
                p.ImageUrl = "/images/" + filename + extension;
            }
            _context.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString(),
                                           }
                                    ).ToList();
            ViewBag.v = values;

            var value = _context.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            if (p.ImageFile != null)
            {
                //uygulamanın çalıştığ dizi al
                var currentDirectory = Directory.GetCurrentDirectory();
                //uygulamanın uzantısını al
                var extension = Path.GetExtension(p.ImageFile.FileName);
                // benzersiz bir dosya adı oluştur
                var filename = Guid.NewGuid().ToString();
                //kayıt edilecek dosyanın yolu
                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images", filename + extension);
                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);
                //dosyayı fiziksel olarak sunucuya yazar
                p.ImageFile.CopyTo(stream);
                p.ImageUrl = "/images/" + filename + extension;
            }
            _context.Products.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}