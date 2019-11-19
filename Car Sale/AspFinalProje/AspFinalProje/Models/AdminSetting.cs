using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspFinalProje.Models
{
    public class AdminSetting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Adı  daxil edin")]
        [StringLength(50, ErrorMessage = "Duzgun Ad daxil edin!")]
        [MinLength(3, ErrorMessage = "Adi daxil edin!")]
        public string Firstname { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Duzgun Soyad daxil edin!")]
        [Required(ErrorMessage = "Soyadı daxil edin")]
        [StringLength(50, ErrorMessage = "Duzgun Soyad daxil edin!")]
        [MinLength(3, ErrorMessage = "Soyadi daxil edin!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email daxil edin")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Duzgun Email Daxil Edin!")]
        [Index("UN_Email", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Duzgun Email daxil edin")]
        [MinLength(5, ErrorMessage = "Duzgun Email daxil edin")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Parol qisadir!")]
        [StringLength(300)]
        [Required(ErrorMessage = "Parolu Daxil Edin")]
        public string Password { get; set; }
    }
}