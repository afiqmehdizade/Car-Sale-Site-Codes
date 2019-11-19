using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspFinalProje.DATA;
using AspFinalProje.Models;

namespace AspFinalProje.ViewModels
{
    public class ForLayout
    {
        public List<Marka> markas { get; set; }
        public List<Advert> adverts { get; set; }
        public List<New> news { get; set; }
        public Advert vmadvert { get; set; }
        public New vmnew{ get; set; }
    }
}