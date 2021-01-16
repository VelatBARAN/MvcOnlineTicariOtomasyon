using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."),DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [DisplayName("Yetki")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(1, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Yetki { get; set; }
    }
}