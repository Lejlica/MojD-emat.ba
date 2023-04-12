
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportApp
{
    public class ReportSadrzaj
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

       public static List<ReportSadrzaj> Get()
       {
            return new List<ReportSadrzaj> { };
       }
    }
}