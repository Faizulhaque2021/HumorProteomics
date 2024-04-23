using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Repository
{
    public class ProteinDataRepository : IProteinData
    {
        public ProteinData AddProteinData(ProteinData prod)
        {
            throw new NotImplementedException();
        }

        public void DeleteProteinData(int id)
        {
            throw new NotImplementedException();
        }

        public ProteinData Details(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProteinData> GetAllProteinData(string sortProperty, SortOrder sortOrder, string SearchText = "")
        {
            throw new NotImplementedException();
        }

        public ProteinData GetProteinDataById(int id)
        {
            throw new NotImplementedException();
        }

        public ProteinData UpdateProteinData(ProteinData uprod)
        {
            throw new NotImplementedException();
        }
    }
}
