namespace HumorProteomics.Models
{
    public class Protein_Data
    {
        public int SampleID { get; set; }
        public int AccessionID { get; set; }
        public double Score { get; set; }
        public double Coverage { get; set; }
        public int Proteins { get; set; }
        public int UniquePeptides { get; set; }
        public int Peptides { get; set; }
        public int PSM { get; set; }
        public int AA { get; set; }
        public double MWK { get; set; }
        public double Calc { get; set; }
    }
}
