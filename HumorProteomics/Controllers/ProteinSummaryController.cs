using HumorProteomics.DbContext;
using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Controllers
{
    public class ProteinSummaryController : Controller
    {
        private readonly HumorDbContext  _context;
        private readonly IProteinSummary _prosum;
        public ProteinSummaryController(IProteinSummary prosum, HumorDbContext context)
        {
            this._context = context;
            this._prosum = prosum;
        }

        private SortModel ApplySort(string SortExpression) 
        {
            ViewData["SortParamName"] = "Name";
            ViewData["SortParamDesc"] = "PortName";

            ViewData["SortIconName"] = "";
            ViewData["SortIconDesc"] = "";

            SortModel sortModel = new SortModel();

            switch (SortExpression.ToLower()) 
            {
                case "name_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "Name";
                    ViewData["SortParamName"] = "Name";
                    ViewData["SortIconName"] = "";
                    break;

                case "ProtName":
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "ProtName";
                    ViewData["SortParamDesc"] = "ProtName";
                    break ;

                case "ProtName_desc":
                    sortModel.SortedOrder = SortOrder.Descending;
                    sortModel.SortedProperty = "ProtName";
                    break;

                default:
                    sortModel.SortedOrder = SortOrder.Ascending;
                    sortModel.SortedProperty = "Name";
                    ViewData["SortIconName"] = "";
                    ViewData["SortParamName"] = "name_desc";
                    break;
            }
            return sortModel;
        }


        public IActionResult Index(string sortExpression="", string SearchText="", int pg=1 ,int pageSize =10)
        {
            SortModel sortModel = ApplySort(sortExpression);
            ViewBag.SearchText = SearchText;
            List<ProteinSummary> prosm = _prosum.GetAllProteinSummary(sortModel.SortedProperty,sortModel.SortedOrder, SearchText);
            PaginatedList<ProteinSummary> proteinsum = new PaginatedList<ProteinSummary>(prosm, pg, pageSize);
            var pager = new PagerModel(proteinsum.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            return View(proteinsum);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProteinSummary prosum) 
        {
            try
            {
                _prosum.AddProteinSummary(prosum);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var proteinsummary = _prosum.GetProteinSummaryById(id);
            return View(proteinsummary);
        }

        [HttpPost]
        public IActionResult Edit(ProteinSummary prosum) 
        {
            _prosum.UpdateProteinSummary(prosum);
            _context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Details(int id) 
        {
            var proteinsummary = _prosum.GetProteinSummaryById(id);
            return View(proteinsummary);
        }

        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var proteinsummary = _context.ps.Find(id);
            return View(proteinsummary);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id) 
        {
            _prosum.DeleteProteinSummary(id);
            _context.SaveChanges(true);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
