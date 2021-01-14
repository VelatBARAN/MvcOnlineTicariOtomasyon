using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public char FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public char FaturaSiraNo { get; set; }

        public DateTime FaturaTarihi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}