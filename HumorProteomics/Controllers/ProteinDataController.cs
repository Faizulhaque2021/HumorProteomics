using HumorProteomics.DbContext;
using HumorProteomics.Interface;
using HumorProteomics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Controllers
{
    public class ProteinDataController : Controller
    {
        private readonly HumorDbContext _context;
        private readonly IProteinData _prodata;
        public ProteinDataController(IProteinData Prodata, HumorDbContext context)
        {
            this._context = context;
            this._prodata = Prodata;
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
            List<ProteinData> proteinDat = _prodata.GetAllProteinData(sortModel.SortedProperty, sortModel.SortedOrder, SearchText,pg,pageSize);
            PaginatedList<ProteinData> proteinDatas = new PaginatedList<ProteinData>(proteinDat, pg, pageSize);
            var pager = new PagerModel(proteinDatas.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            return View(proteinDatas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(ProteinData proteinData)
        {
            try
            {
                _prodata.AddProteinData(proteinData);
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
            var proteinData = _prodata.GetProteinDataById(id);
            return View(proteinData);
        }

        [HttpPost]
        public IActionResult Edit(ProteinData proteinData)
        {
            _prodata.UpdateProteinData(proteinData);
            _context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var proteindata = _prodata.GetProteinDataById(id);
            return View(proteindata);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proteindata = _context.pd.Find(id);
            return View(proteindata);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _prodata.DeleteProteinData(id);
            _context.SaveChanges(true);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
