using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]

        public int FaturaID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string FaturaSiraNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSeriNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string FaturaVergiDairesi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTeslimAlan { get; set; }

        public decimal FaturaToplam { get; set; }

        public ICollection<FaturaKalem> faturaKalems { get; set; }
    }

}