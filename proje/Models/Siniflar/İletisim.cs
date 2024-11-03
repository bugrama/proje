using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje.Models.Siniflar
{
    public class İletisim
    {
        [Key]
        public int Id { get; set; }
        public string adsoyad { get; set; }
        public string mail { get; set; }
        public string konu { get; set; }
        public string mesaj { get; set; }
    }
}