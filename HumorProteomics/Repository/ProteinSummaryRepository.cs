using HumorProteomics.DbContext;
using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Repository
{
    public class ProteinSummaryRepository : IProteinSummary
    {
        private readonly HumorDbContext _context;
        public ProteinSummaryRepository(HumorDbContext context)
        {
            this._context = context;
        }
        public ProteinSummary AddProteinSummary(ProteinSummary psum)
        {
            _context.ps.Add(psum);
            _context.SaveChanges();
            return psum;
        }

        public void DeleteProteinSummary(int id)
        {
            ProteinSummary? delpsm = _context.ps.FirstOrDefault(p=>p.ProteinSummaryID == id);
            if (delpsm !=null)
            {
                _context.ps.Remove(delpsm);
                _context.SaveChanges();
            }
        }

        public ProteinSummary Details(int id)
        {
            ProteinSummary? psm = _context.ps.FirstOrDefault(p=> p.ProteinSummaryID == id);
            return psm;
        }

        private List<ProteinSummary> DoSort(List<ProteinSummary> psm, string SortProperty, SortOrder sortOrder) 
        {
            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    psm = psm.OrderBy(n=> n.ProtName).ToList();
                    psm = psm.OrderByDescending(n=> n.ProtName).ToList();
                }
            }
            else 
            {
                if (sortOrder == SortOrder.Ascending )
                {
                    psm = psm.OrderBy(p => p.ProtName).ToList();
                    psm = psm.OrderByDescending(p => p.ProtName).ToList();
                }
            }
            return psm;
        }

        public List<ProteinSummary> GetAllProteinSummary(string sortProperty, SortOrder sortOrder, string SearchText = "")
        {
            List<ProteinSummary> psm = _context.ps.ToList();
            if (SearchText !="" && SearchText !=null)
            {
                psm = _context.ps.Where(n => n.ProtName.Contains(SearchText) || n.ProtName.Contains(SearchText)).ToList();

            }
            else
            {
                psm = _context.ps.ToList();
            }
            psm = DoSort(psm, sortProperty, sortOrder);
            return psm;
        }

        public ProteinSummary GetProteinSummaryById(int id)
        {
            ProteinSummary? psm = _context.ps.FirstOrDefault( p=> p.ProteinSummaryID == id);
            return psm;
        }

        public ProteinSummary UpdateProteinSummary(ProteinSummary upsm)
        {
            ProteinSummary? psm = _context.ps.FirstOrDefault(p => p.ProteinSummaryID == upsm.ProteinSummaryID);
            psm.ProteinSummaryID = upsm.ProteinSummaryID;
            psm.ProtName = upsm.ProtName;
            psm.GeSymbol = upsm.GeSymbol;
            psm.AccessionID = upsm.AccessionID;
            psm.GeNames = upsm.GeNames;
            psm.TotalPs = upsm.TotalPs;
            psm.MePSMs = upsm.MePSMs;
            psm.Detected = upsm.Detected;
            _context.SaveChanges();
            return upsm;
        }
    }
}
