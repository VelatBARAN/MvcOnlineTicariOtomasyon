using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} alanı boş geçilemez"), StringLength(30,ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string KategoriAd { get; set;}
     
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}