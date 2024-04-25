﻿using System.ComponentModel.DataAnnotations;

namespace HumorProteomics.Models
{
    public class ProteinSummary
    {

        public int ProteinSummaryID { get; set; }

        [Display(Name = "AccessionID")]
        [Required]
        [StringLength(10)]
        public string? AccessionID { get; set; }

        [Display(Name = "Gene Symbol")]
        [Required]
        [StringLength(10)]
        public string? GeSymbol { get; set; }

        [Display(Name = "Protein Name")]
        [Required]
        [StringLength(10)]
        public string? ProtName { get; set; }

        [Display(Name = "Gene Names")]
        [Required]
        [StringLength(10)]
        public string? GeNames { get; set; }

        [Display(Name = "Total PSMs")]
        [Required]
        public int TotalPs { get; set; }

        [Display(Name = "Mean PSMs")]
        [Required]
        public int MePSMs { get; set; }

        [Display(Name = "Detected in (%)")]
        [Required]
        public int Detected { get; set; }
    }
}
