using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AspFinalProje.Models
{
    public class Oil
    {
        public Oil()
        {
            Avtomobil = new HashSet<Avtomobil>();
        }
        public int Id { get; set; }
        [StringLength(30,ErrorMessage ="daxil etdiyiniz melumat yanlisdir!")]
        public string YanacaqAdi { get; set; }

        public virtual ICollection<Avtomobil>Avtomobil { get; set; }
    }
}