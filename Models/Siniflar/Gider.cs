using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(250, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Aciklama { get; set; }

        [DisplayName("Tarih")]
        public DateTime Tarih { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public decimal Tutar { get; set; }
    }
}