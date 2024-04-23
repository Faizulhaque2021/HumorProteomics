using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Interface
{
    public interface IClinicalData
    {
        List<ClinicalData> GetAllClinicalData(string sortProperty, SortOrder sortOrder, string SearchText = "");
        ClinicalData GetClinicalDataById(int id);
        ClinicalData AddClinicalData(ClinicalData cld);
        ClinicalData UpdateClinicalData(ClinicalData ucld);
        ClinicalData Details(int id);
        void DeleteClinicalData(int id);
    }
}
