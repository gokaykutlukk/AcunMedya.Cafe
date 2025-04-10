using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedya.Cafe.Controllers
{
    public class ProductController : Controller
    {
        private readonly CafeContext _context;

        public ProductController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Eager Loading


            var values = _context.Products.Include(x=>x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            if(model.ImageFile != null)
            {
                // uygulamanın çalıştığı dizini alıyoruz
                var currenDirectory = Directory.GetCurrentDirectory();

                // resim dosyasının uzantısını alıyoruz jpg , png, jpeg
                var extension = Path.GetExtension(model.ImageFile.FileName);
                //benzersiz dosya oluşturuyoruz
                var fileName = Guid.NewGuid().ToString();
                // resim dosyasını kaydetmek için bir yol oluşturuyoruz
                var saveLocation = Path.Combine(currenDirectory + "/wwwroot/images/", fileName + extension);
                // resim dosyasını kaydediyoruz
                var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl= "/images/" + fileName + extension;
            }

            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id) 
        {
            var values = _context.Products.Find(id);
            List<SelectListItem> valuesCategory = (from x in _context.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.v = valuesCategory;
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product model)
        {
            if (model.ImageFile != null)
            {
                // uygulamanın çalıştığı dizini alıyoruz
                var currenDirectory = Directory.GetCurrentDirectory();

                // resim dosyasının uzantısını alıyoruz jpg , png, jpeg
                var extension = Path.GetExtension(model.ImageFile.FileName);
                //benzersiz dosya oluşturuyoruz
                var fileName = Guid.NewGuid().ToString();
                // resim dosyasını kaydetmek için bir yol oluşturuyoruz
                var saveLocation = Path.Combine(currenDirectory + "/wwwroot/images/", fileName + extension);
                // resim dosyasını kaydediyoruz
                var stream = new FileStream(saveLocation, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                model.ImageUrl = "/images/" + fileName + extension;
            }

            _context.Products.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var values = _context.Products.Find(id);
            _context.Products.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
