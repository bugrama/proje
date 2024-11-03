using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje.Models.Siniflar
{
    public class TurYorum
    {
        public IEnumerable<Turlar> Deger1 { get; set; }
        public IEnumerable<Yorumlar> Deger2 { get; set; }
        public IEnumerable<Turlar> Deger3 { get; set; }
    }
}