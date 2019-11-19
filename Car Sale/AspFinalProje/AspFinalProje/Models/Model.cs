using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspFinalProje.Models
{
    public class Model
    {
        public Model()
        {
            Avtomobil = new HashSet<Avtomobil>();
        }
        public int Id { get; set; }
        [StringLength(50,ErrorMessage ="Maksimum 50 simbol daxil ede bilersiniz!")]
        [MinLength(2,ErrorMessage ="Minimum 2 simbol daxil ede bilersiniz!")]
        public string ModelName { get; set; }
        public int MarkaId { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual ICollection<Avtomobil> Avtomobil { get; set; }
    }
}