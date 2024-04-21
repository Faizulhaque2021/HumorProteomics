namespace HumorProteomics.Models
{
    public class Protein_Summary
    {
        public int AccessionID { get; set; }
        public string GeSymbol { get; set; }
        public string ProtName { get; set; }
        public string GeNames { get; set; }
        public int TotalPs { get; set; }
        public double MePSMs { get; set; }
        public int Detected { get; set; }
    }
}
