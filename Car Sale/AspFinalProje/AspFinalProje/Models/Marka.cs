using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProje.Models
{
    public class Marka
    {
        public Marka()
        {
            Models = new HashSet<Model>();
        }
        public int Id { get; set; }
        [StringLength(50,ErrorMessage ="Maksimum 50 simvol yaza bilersiniz!")]
        [MinLength(2,ErrorMessage ="Minimum 2 simvol yazmalisiniz!")]
        public string MarkaName { get; set; }
        
        public virtual ICollection<Model> Models { get; set; }
    }
}