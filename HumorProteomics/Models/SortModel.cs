using Microsoft.Data.SqlClient;

namespace HumorProteomics.Models
{
    public class SortModel
    {
        public string? SortedProperty { get; set; }
        public SortOrder SortedOrder { get; set; }
    }
}
