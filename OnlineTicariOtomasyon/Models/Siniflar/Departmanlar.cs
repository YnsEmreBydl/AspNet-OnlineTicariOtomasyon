using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Departmanlar
    {

        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Departman_ad { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}