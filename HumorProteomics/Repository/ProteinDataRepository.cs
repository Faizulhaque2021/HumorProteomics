using HumorProteomics.DbContext;
using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Repository
{
    public class ProteinDataRepository : IProteinData
    {
        private readonly HumorDbContext _context;
        public ProteinDataRepository(HumorDbContext context)
        {
            this._context = context;
        }

        public ProteinData AddProteinData(ProteinData prod)
        {
            _context.pd.Add(prod);
            _context.SaveChanges();
            return prod;
        }

        public void DeleteProteinData(int id)
        {
            ProteinData? delprod = _context.pd.FirstOrDefault(d => d.ProteinDataID == id);
            if (delprod != null)
            {
                _context.pd.Remove(delprod);
                _context.SaveChanges();
            }
        }

        public ProteinData Details(int id)
        {
            ProteinData? prod = _context.pd.FirstOrDefault(d => d.ProteinDataID == id);
            return prod;
        }

        private List<ProteinData> DoSort(List<ProteinData> prodata, string SortProperty, SortOrder sortOrder)
        {
            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    prodata = prodata.OrderBy(p => p.Proteins).ToList();
                    prodata = prodata.OrderByDescending(p => p.Proteins).ToList();
                }
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    prodata = prodata.OrderBy(p => p.Proteins).ToList();
                    prodata = prodata.OrderByDescending(p => p.Proteins).ToList();
                }
            }
            return prodata;
        }

        public List<ProteinData> GetAllProteinData(string sortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 10)
        {
            List<ProteinData> prodata = _context.pd.ToList();
            if (SearchText != "" && SearchText != null)
            {
                prodata = _context.pd.Where(p => p.AccessionID.Contains(SearchText) || p.AccessionID.Contains(SearchText)).ToList();

            }
            else
            {
                prodata = _context.pd.ToList();
            }
            prodata = DoSort(prodata, sortProperty, sortOrder);
            PaginatedList<ProteinData> reprodata = new PaginatedList<ProteinData>(prodata, pageIndex, pageSize);
            return prodata;
        }

        public ProteinData GetProteinDataById(int id)
        {
            ProteinData? prod = _context.pd.FirstOrDefault(d => d.ProteinDataID == id);
            return prod;
        }

        public ProteinData UpdateProteinData(ProteinData uprod)
        {
            ProteinData? prod = _context.pd.FirstOrDefault(d => d.ProteinDataID == uprod.ProteinDataID);
            prod.ProteinDataID = uprod.ProteinDataID;
            prod.SampleID = uprod.SampleID;
            prod.AccessionID = uprod.AccessionID;
            prod.Score = uprod.Score;
            prod.Coverage = uprod.Coverage;
            prod.Proteins = uprod.Proteins;
            prod.UniquePeptides = uprod.UniquePeptides;
            prod.Peptides = uprod.Peptides;
            prod.PSM = uprod.PSM;
            prod.AA = uprod.AA;
            prod.MWK = uprod.MWK;
            prod.Calc = uprod.Calc;
            _context.SaveChanges();
            return uprod;
        }
    }
}
