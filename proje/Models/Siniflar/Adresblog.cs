using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje.Models.Siniflar
{
    public class Adresblog
    {
        [Key]
        public int Id { get; set; }
        public string baslık { get; set; }
        public string acıklama { get; set; }
        public string adresi { get; set; }
        
    }
}