using System.ComponentModel.DataAnnotations;

namespace HumorProteomics.Models
{
    public class ClinicalData
    {
        public int ClinicalDataID { get; set; }

        [Display(Name = "SampleID")]
        [Required]
        public int SampleID { get; set; }

        [Display(Name = "C/G")]
        [Required]
        [StringLength(10)]
        public string? CG { get; set; }

        [Display(Name = "Sex")]
        [Required]
        [StringLength(10)]
        public string? Sex { get; set; }

        [Display(Name = "Age")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Race")]
        [Required]
        [StringLength(10)]
        public string? Race { get; set; }

        [Display(Name = "Ethnicity")]
        [Required]
        [StringLength(100)]
        public string? Ethnicity { get; set; }

        [Display(Name = "IOP")]
        [Required]
        public int IOP { get; set; }

        [Display(Name = "IOP Method")]
        [Required]
        [StringLength(10)]
        public string? IOPM { get; set; }

        [Display(Name = "OD/OS")]
        [Required]
        [StringLength(10)]
        public string? OD { get; set; }

        [Display(Name = "Incisional")]
        [Required]
        [StringLength(10)]
        public string? Incisional { get; set; }

        [Display(Name = "Smoking")]
        [Required]
        [StringLength(10)]
        public string? Smoking { get; set; }

        [Display(Name = "HTN")]
        [Required]
        [StringLength(10)]
        public string? HTN { get; set; }

        [Display(Name = "CVD")]
        [Required]
        [StringLength(10)]
        public string? CVD { get; set; }

        [Display(Name = "CVA")]
        [Required]
        [StringLength(10)]
        public string? CVA { get; set; }

        [Display(Name = "Collagen VD")]
        [Required]
        [StringLength(10)]
        public string? Collagen { get; set; }

        [Display(Name = "Diabetes")]
        [Required]
        [StringLength(10)]
        public string? Diabetes { get; set; }

        [Display(Name = "Other Systemic Diseases")]
        [Required]
        [StringLength(10)]
        public string? SysDiseases { get; set; }

        [Display(Name = "Glaucoma")]
        [Required]
        [StringLength(10)]
        public string? Glaucoma { get; set; }

        [Display(Name = "Cataract")]
        [Required]
        [StringLength(10)]
        public string? Cataract { get; set; }

        [Display(Name = "Dry Eye Syndrome")]
        [Required]
        [StringLength(10)]
        public string? DryEye { get; set; }

        [Display(Name = "Laser")]
        [Required]
        [StringLength(10)]
        public string? Laser { get; set; }

        [Display(Name = "DR")]
        [Required]
        [StringLength(10)]
        public string? DR { get; set; }

        [Display(Name = "Diab Laser")]
        [Required]
        [StringLength(10)]
        public string? DiabL { get; set; }

        [Display(Name = "Other Eye Disease")]
        [Required]
        [StringLength(10)]
        public string? OEyeD { get; set; }
    }
}
