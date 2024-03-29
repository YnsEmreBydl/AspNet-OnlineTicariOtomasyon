﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KullaniciAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Sifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}