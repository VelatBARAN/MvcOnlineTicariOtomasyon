using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public DateTime Tarih { get; set; }

        [DisplayName("Adet")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int Adet { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public decimal Fiyat { get; set; }

        [DisplayName("Toplam Tutar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"),]
        public decimal ToplamTutar { get; set; }

        [DisplayName("Ürün")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int UrunId { get; set; }

        [DisplayName("Cari")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int CariId { get; set; }

        [DisplayName("Personel")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int PersonelId { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}