using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Repository
{
    public class ProteinSummaryRepository : IProteinSummary
    {
        public ProteinSummary AddProteinSummary(ProteinSummary psum)
        {
            throw new NotImplementedException();
        }

        public void DeleteProteinSummary(int id)
        {
            throw new NotImplementedException();
        }

        public ProteinSummary Details(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProteinSummary> GetAllProteinSummary(string sortProperty, SortOrder sortOrder, string SearchText = "")
        {
            throw new NotImplementedException();
        }

        public ProteinSummary GetProteinSummaryById(int id)
        {
            throw new NotImplementedException();
        }

        public ProteinSummary UpdateProteinSummary(ProteinSummary upsm)
        {
            throw new NotImplementedException();
        }
    }
}
