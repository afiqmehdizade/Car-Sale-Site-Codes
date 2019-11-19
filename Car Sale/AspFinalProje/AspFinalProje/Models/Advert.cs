using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProje.Models
{
    public class Advert
    {
        public int Id { get; set; }
        [Display(Name ="Yaranma Tarixi")]
        public DateTime CreatedAt { get; set; }
        [Display(Name ="Dəyişdirilmə Tarixi")]
        public DateTime UpdatedAt { get; set; }
        [Display(Name ="Şəhəri")]
        public int CityId { get; set; }
        [Display(Name ="Statusu")]
        public bool IsVip { get; set; }
        public int AvtomobilId { get; set; }
        [Display(Name ="İstifadəçi")]
        public int UserId { get; set; }

        public virtual Avtomobil Avtomobil { get; set; }
        public virtual City City { get; set; }
        public virtual User User { get; set; }
    }
}