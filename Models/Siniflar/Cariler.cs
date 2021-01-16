using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId  { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Cari Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Cari Soyad")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(15, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("EMail")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string CariMail { get; set; }

        [DefaultValue(true)]
        public bool Durum { get; set; }

        public virtual ICollection<SatisHareket> SatisHareket { get; set; }  
    }
}