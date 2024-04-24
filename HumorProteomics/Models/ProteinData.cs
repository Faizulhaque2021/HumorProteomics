using System.ComponentModel.DataAnnotations;

namespace HumorProteomics.Models
{
    public class ProteinData
    {
        public int ProteinDataID { get; set; }

        [Display(Name = "SampleID")]
        [Required]
        public int SampleID { get; set; }

        [Display(Name = "AccessionID")]
        [Required]
        [StringLength(1000)]
        public string? AccessionID { get; set; }

        [Display(Name = "Score")]
        [Required]
        public double Score { get; set; }

        [Display(Name = "Coverage")]
        [Required]
        public double Coverage { get; set; }

        [Display(Name = "Proteins")]
        [Required]
        public int Proteins { get; set; }

        [Display(Name = "Unique Peptides")]
        [Required]
        public int UniquePeptides { get; set; }

        [Display(Name = "Peptides")]
        [Required]
        public int Peptides { get; set; }

        [Display(Name = "PSMs")]
        [Required]
        public int PSM { get; set; }

        [Display(Name = "AAs")]
        [Required]
        public int AA { get; set; }

        [Display(Name = "MW KDA")]
        [Required]
        public double MWK { get; set; }

        [Display(Name = "Calc PI")]
        [Required]
        public double Calc { get; set; }
    }
}
