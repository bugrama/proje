using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int Id { get; set; }
        public string Rumuz { get; set; }
        public string mail { get; set; }
        public string yorum { get; set; }
        public int Turid { get; set; }
        public virtual Turlar Tur { get; set; }
    }
}