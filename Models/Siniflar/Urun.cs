using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName ="Varchar")]
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Marka")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Marka { get; set; }

        public short Stok { get; set; }

        [DisplayName("Alış Fiyatı")]
        public decimal AlisFiyat { get; set; }

        [DisplayName("Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }

        [DefaultValue(true)]
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Ürün Görsel")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(250, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string UrunGorsel { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int KategoriId { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<SatisHareket> SatisHareket { get; set; }

    }
}