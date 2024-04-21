using HumorProteomics.Models;
using Microsoft.EntityFrameworkCore;

namespace HumorProteomics.DbContext
{
    public class HumorDbContext
    {
        public HumorDbContext(DbContextOptions  options) : base() 
        { 
        }
        public virtual DbSet<Clinical_Data> cd { get; set; }
        public virtual DbSet<Protein_Data> pd { get; set; }
        public virtual DbSet<Protein_Summary> ps { get; set; }
        public virtual DbSet<Data_Download> dd { get; set; }

    }
}
