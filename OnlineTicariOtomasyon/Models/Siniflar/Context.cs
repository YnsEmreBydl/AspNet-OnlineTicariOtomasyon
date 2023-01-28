using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins  { get; set; }
        public DbSet<Cariler> Carilers  { get; set; }
        public DbSet<Departmanlar> Departmanlars  { get; set; }
        public DbSet<FaturaKalem> FaturaKalems  { get; set; }
        public DbSet<Faturalar> Faturalars  { get; set; }
        public DbSet<Giderler> Giderlers  { get; set; }
        public DbSet<Personel> Personels  { get; set; }
        public DbSet<Kategori> Kategoris  { get; set; }
        public DbSet<Urunler> Urunlers  { get; set; }
        public DbSet<SatisHareket> SatisHarekets  { get; set; }
    }
}