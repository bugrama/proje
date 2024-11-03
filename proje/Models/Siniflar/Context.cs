using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace proje.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Adresblog> Adresblogs { get; set; }   
        public DbSet<Turlar> Turlars { get; set; }   
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }   
        public DbSet<İletisim> İletisims { get; set; }   
        public DbSet<Yorumlar> Yorumlars { get; set; }    

    }
}