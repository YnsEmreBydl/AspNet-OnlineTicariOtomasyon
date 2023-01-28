using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {

        [Key]
        public int KategoriID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Kategori_ad { get; set; }

        public ICollection<Urunler> Urunlers { get; set; }
    }
}