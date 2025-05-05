using System.ComponentModel.DataAnnotations;

namespace AcunMedya.Cafe.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
