using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Interface
{
    public interface IProteinSummary
    {
        List<ProteinSummary> GetAllProteinSummary(string sortProperty, SortOrder sortOrder, string SearchText = "");
        ProteinSummary GetProteinSummaryById(int id);
        ProteinSummary AddProteinSummary(ProteinSummary psum);
        ProteinSummary UpdateProteinSummary(ProteinSummary upsm);
        ProteinSummary Details(int id);
        void DeleteProteinSummary(int id);
    }
}
