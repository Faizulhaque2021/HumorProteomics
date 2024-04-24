using HumorProteomics.DbContext;
using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Repository
{
    public class ClinicalDataRepository : IClinicalData
    {
        private readonly HumorDbContext _context;
        public ClinicalDataRepository(HumorDbContext context)
        {
            this._context = context;
        }

        public ClinicalData AddClinicalData(ClinicalData cld)
        {
            _context.cd.Add(cld);
            _context.SaveChanges();
            return cld;
        }

        public void DeleteClinicalData(int id)
        {
            ClinicalData? delcld = _context.cd.FirstOrDefault(c => c.ClinicalDataID == id);
            if (delcld != null)
            {
                _context.cd.Remove(delcld);
                _context.SaveChanges();
            }
        }

        public ClinicalData Details(int id)
        {
            ClinicalData? cld = _context.cd.FirstOrDefault(c=> c.ClinicalDataID == id);
            return cld;
        }

        private List<ClinicalData> DoSort(List<ClinicalData> cld, string SortProperty, SortOrder sortOrder)
        {
            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    cld = cld.OrderBy(c => c.DiabL).ToList();
                    cld = cld.OrderByDescending(c => c.DiabL).ToList();
                }
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    cld = cld.OrderBy(c => c.DiabL).ToList();
                    cld = cld.OrderByDescending(c => c.DiabL).ToList();
                }
            }
            return cld;
        }

        public List<ClinicalData> GetAllClinicalData(string sortProperty, SortOrder sortOrder, string SearchText = "")
        {
            List<ClinicalData> cld = _context.cd.ToList();
            if (SearchText != "" && SearchText != null)
            {
                cld = _context.cd.Where(c => c.DiabL.Contains(SearchText) || c.DiabL.Contains(SearchText)).ToList();

            }
            else
            {
                cld = _context.cd.ToList();
            }
            cld = DoSort(cld, sortProperty, sortOrder);
            return cld;
        }

        public ClinicalData GetClinicalDataById(int id)
        {
            ClinicalData? cld = _context.cd.FirstOrDefault(c => c.ClinicalDataID == id);
            return cld;
        }

        public ClinicalData UpdateClinicalData(ClinicalData ucld)
        {
            ClinicalData? cld = _context.cd.FirstOrDefault(c => c.ClinicalDataID == ucld.ClinicalDataID);
            cld.ClinicalDataID = ucld.ClinicalDataID;
            cld.SampleID = ucld.SampleID;
            cld.CG = ucld.CG;
            cld.Sex = ucld.Sex;
            cld.Age = ucld.Age;
            cld.Race = ucld.Race;
            cld.Ethnicity = ucld.Ethnicity;
            cld.IOP = ucld.IOP;
            cld.IOPM = ucld.IOPM;
            cld.OD = ucld.OD;
            cld.Incisional = ucld.Incisional;
            cld.Smoking = ucld.Smoking;
            cld.HTN = ucld.HTN;
            cld.CVD = ucld.CVD;
            cld.CVA = ucld.CVA;
            cld.Collagen = ucld.Collagen;
            cld.Diabetes = ucld.Diabetes;
            cld.SysDiseases = ucld.SysDiseases;
            cld.Glaucoma = ucld.Glaucoma;
            cld.Cataract = ucld.Cataract;
            cld.DryEye = ucld.DryEye;
            cld.Laser = ucld.Laser;
            cld.DR = ucld.DR;
            cld.DiabL = ucld.DiabL;
            cld.OEyeD = ucld.OEyeD;
            _context.SaveChanges();
            return ucld;
        }
    }
}
