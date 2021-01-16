using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayName("Departman Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DepartmanAd { get; set; }

        [DefaultValue(true)]
        public bool Durum { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}