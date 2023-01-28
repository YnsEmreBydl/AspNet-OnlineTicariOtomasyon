using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Personel_ad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Personel_soyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Personel_resim { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int Departmanid { get; set; }
        public virtual Departmanlar Departmanlar { get; set; }
    }
}