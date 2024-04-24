using HumorProteomics.DbContext;
using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Controllers
{
    public class ClinicalDataController : Controller
    {
        private readonly HumorDbContext _context;
        private readonly IClinicalData _clinicalData;
        public ClinicalDataController(IClinicalData ClinicalData, HumorDbContext context)
        {
            this._context = context;
            this._clinicalData = ClinicalData;
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
                    break;

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

        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 10)
        {
            SortModel sortModel = ApplySort(sortExpression);
            ViewBag.SearchText = SearchText;
            List<ClinicalData> clinidata = _clinicalData.GetAllClinicalData(sortModel.SortedProperty, sortModel.SortedOrder, SearchText);
            PaginatedList<ClinicalData> cldata = new PaginatedList<ClinicalData>(clinidata, pg, pageSize);
            var pager = new PagerModel(cldata.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            return View(cldata);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClinicalData cldata)
        {
            try
            {
                _clinicalData.AddClinicalData(cldata);
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
            var clinicaldata = _clinicalData.GetClinicalDataById(id);
            return View(clinicaldata);
        }

        [HttpPost]
        public IActionResult Edit(ClinicalData cldata)
        {
            _clinicalData.UpdateClinicalData(cldata);
            _context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var clinicaldata = _clinicalData.GetClinicalDataById(id);
            return View(clinicaldata);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clinicaldata = _context.cd.Find(id);
            return View(clinicaldata);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _clinicalData.DeleteClinicalData(id);
            _context.SaveChanges(true);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
