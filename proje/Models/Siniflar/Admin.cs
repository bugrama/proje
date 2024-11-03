using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string kullanıcı { get; set; }
        public string sifre { get; set; }
    }
}