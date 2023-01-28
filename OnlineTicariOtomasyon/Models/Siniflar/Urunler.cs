using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Urun_ad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Urun_Marka { get; set; }
     
        public decimal Urun_alis_fiyat { get; set; }
        public decimal Urun_satis_fiyat { get; set; }
        public bool Urun_durum{ get; set; }
        public short Urun_stok{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Urun_gorsel{ get; set; }
        public int Kategoriid{ get; set; }
        public virtual Kategori Kategori{ get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}