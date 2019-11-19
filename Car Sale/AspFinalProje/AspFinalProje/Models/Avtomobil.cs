using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspFinalProje.Models
{
    public class Avtomobil
    {  
        public int Id { get; set; }
        [Range(50,1000000,ErrorMessage = "Duzgun qiymet daxil edin")]
        [StringLength(10,ErrorMessage = "Duzgun qiymet daxil edin")]
        [Required(ErrorMessage ="Qiymeti daxil edin")]
        public string Price { get; set; }
        
        [Display(Name ="Model")]
        [Required(ErrorMessage ="Modeli daxil edin")]
        public int ModelId { get; set; }

        [StringLength(4,ErrorMessage ="Duzgun il daxil edin")]
        [Required(ErrorMessage ="Istehsal ilini daxil edin")]
        public string MadeYear { get; set; }

        [Range(20, 1000, ErrorMessage = "Duzgun deyer daxil edin")]
        [Required(ErrorMessage ="Motor gucunu daxil edin")]
        public string EngineCapacity { get; set; }

        [Required(ErrorMessage ="Surus deyerini daxil edin")]
        public int KiloMetre { get; set; }

        [StringLength(20,ErrorMessage ="Duzgun reng daxil edin")]
        [DataType(DataType.Text)]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Duzgun reng daxil edin ")]
        [Required(ErrorMessage ="Rengini daxil edin")]
        public string Color { get; set; }

        [Required(ErrorMessage ="Yanacaq novunu daxil edin")]
        public int OilId { get; set; }

        [Required(ErrorMessage ="Oturucunu daxil edin")]
        public bool TransMission { get; set; }

        [StringLength(500,ErrorMessage ="Maksimum simbol sayini kecdiniz")]
        [Display(Name ="Melumat")]
        [Required(ErrorMessage ="Melumati daxil edin")]
        public string Context { get; set; }

        public string Image { get; set; }

        [Display(Name ="Şəkil")]
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        [NotMapped]
        public int sitild { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual Model Model { get; set; }
        public virtual Oil Oil { get; set; }

    }
}