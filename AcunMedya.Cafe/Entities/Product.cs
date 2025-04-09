using System.ComponentModel.DataAnnotations.Schema;

namespace AcunMedya.Cafe.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped] // veri tabanına kaydedilmemesi için
        public IFormFile ImageFile { get; set; } // resim yüklemek için

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
