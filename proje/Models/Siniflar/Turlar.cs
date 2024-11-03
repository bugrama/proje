using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje.Models.Siniflar
{
    public class Turlar
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Tarih { get; set; }
        public string Aciklama { get; set; }
        public string Resim {  get; set; }
        public ICollection < Yorumlar> Yorumlars { get; set; }

    }
}