using HumorProteomics.Models;
using Microsoft.EntityFrameworkCore;

namespace HumorProteomics.DbContext
{
    public class HumorDbContext
    {
        public HumorDbContext(DbContextOptions  options) : base() 
        { 
        }
        public virtual DbSet<ClinicalData> cd { get; set; }
        public virtual DbSet<ProteinData> pd { get; set; }
        public virtual DbSet<ProteinSummary> ps { get; set; }
        public virtual DbSet<DataDownload> dd { get; set; }

    }
}
