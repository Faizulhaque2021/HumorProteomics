using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Repository
{
    public class ClinicalDataRepository : IClinicalData
    {
        public ClinicalData AddClinicalData(ClinicalData cld)
        {
            throw new NotImplementedException();
        }

        public void DeleteClinicalData(int id)
        {
            throw new NotImplementedException();
        }

        public ClinicalData Details(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClinicalData> GetAllClinicalData(string sortProperty, SortOrder sortOrder, string SearchText = "")
        {
            throw new NotImplementedException();
        }

        public ClinicalData GetClinicalDataById(int id)
        {
            throw new NotImplementedException();
        }

        public ClinicalData UpdateClinicalData(ClinicalData ucld)
        {
            throw new NotImplementedException();
        }
    }
}
