using System.ComponentModel.DataAnnotations;

namespace HumorProteomics.Models
{
    public class ProteinData
    {
        public int ProteinDataID { get; set; }

        [Display(Name = "Sample ID")]
        [Required]
        public int SampleID { get; set; }

        [Display(Name = "Accession ID")]
        [Required]
        [StringLength(20)]
        public string? AccessionID { get; set; }

        [Display(Name = "Score")]
        [Required]
        public int Score { get; set; }

        [Display(Name = "Coverage")]
        [Required]
        public int Coverage { get; set; }

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

        [Display(Name = "MW-KDA")]
        [Required]
        public int MWK { get; set; }

        [Display(Name = "Calc-PI")]
        [Required]
        public int Calc { get; set; }
    }
}
