using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proje.Models
{
    public class AlinanSiparisler
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
