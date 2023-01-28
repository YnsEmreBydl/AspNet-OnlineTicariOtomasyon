using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        [StringLength(30 , ErrorMessage ="En fazla 30 karakter girebilirsiniz")]
        public string Cari_ad { get; set; }
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        public string Cari_soyad { get; set; }
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        public string Cari_sehir { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [EmailAddress(ErrorMessage ="Girdiğiniz değer eposta formatında olmalıdır")]
        public string Cari_mail { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}