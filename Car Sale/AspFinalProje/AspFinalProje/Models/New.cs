using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AspFinalProje.Models
{
    public class New
    {
        public int Id { get; set; }
        [Display(Name ="Başlıq")]
        [Required(ErrorMessage ="Basliqi daxil edin"),MinLength(3,ErrorMessage ="Duzgun bashliq daxil edin")]
        [StringLength(50,ErrorMessage ="Maksimum 50 simbol istifade ede bilersiniz!")]
        public string Title { get; set; }
        [Display(Name = "Məzmun")]
        [Required(ErrorMessage = "Melumati daxil edin"), MinLength(3, ErrorMessage = "Duzgun Melumat daxil edin")]
        [StringLength(500, ErrorMessage = "Maksimum 500 simbol istifade ede bilersiniz!")]
        public string Content { get; set; }
        [Display(Name = "Yaradılma Vaxtı")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Şəkil")]
        public string Image { get; set; }
        [NotMapped]
        [Display(Name = "Şəkil")]
        public HttpPostedFileBase Photo { get; set; }
    }
}