using HumorProteomics.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HumorProteomics.DbContext
{
    public class HumorDbContext:IdentityDbContext
    {
        public HumorDbContext(DbContextOptions  options) : base(options) 
        { 
        }
        public virtual DbSet<ClinicalData> cd { get; set; }
        public virtual DbSet<ProteinData> pd { get; set; }
        public virtual DbSet<ProteinSummary> ps { get; set; }
        public virtual DbSet<DataDownload> dd { get; set; }

    }
}
