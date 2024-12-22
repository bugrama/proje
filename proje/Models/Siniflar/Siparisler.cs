using System.ComponentModel.DataAnnotations;

namespace proje.Models
{
    public class Siparisler
    {
        [Key]
        public int Id { get; set; }
        public int TurId { get; set; }
        
        public string Isim { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int Kisi { get; set; }
        
    }
}
