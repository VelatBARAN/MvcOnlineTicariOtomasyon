using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [DisplayName("Fatura Seri No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(1, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Fatura Sıra No")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(10, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string FaturaSiraNo { get; set; }

        [DisplayName("Fatura Tarihi")]
        public DateTime FaturaTarihi { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Vergi Dairesi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Char")]
        [DisplayName("Saat")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(5, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Teslim Eden")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Teslim Alan")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string TeslimAlan { get; set; }

        [DisplayName("Toplam Tutar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public decimal ToplamTutar { get; set; }

        public virtual ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}