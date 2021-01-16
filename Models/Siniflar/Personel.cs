using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Personel Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Personel Soyadı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Personel Görsel")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(250, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string PersonelGorsel { get; set; }

        [DisplayName("Departman Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int DepartmanId { get; set; }

        [DefaultValue(true)]
        public bool Durum { get; set; }

        public virtual ICollection<SatisHareket> SatisHareket { get; set; }
        public virtual Departman Departman { get; set; }
    }
}