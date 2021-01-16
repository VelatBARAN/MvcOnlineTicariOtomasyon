using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(250, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Aciklama { get; set; }

        [DisplayName("Miktar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int Miktar { get; set; }

        [DisplayName("Birim Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public decimal BirimFiyat { get; set; }

        [DisplayName("Tutar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public decimal Tutar { get; set; }

        [DisplayName("Fatura")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int FaturaId { get; set; }

        public virtual Faturalar Faturalar { get; set; }
    }
}