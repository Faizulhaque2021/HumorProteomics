using Microsoft.AspNetCore.Mvc.Rendering;

namespace HumorProteomics.Models
{
    public class PagerModel
    {
        
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int StartRecord { get; set; }
        public int EndRecord { get; set; }

        //public Properties
        public string Action { get; set; } = "Index";
        public string? SearchText { get; set; }
        public string? SortExpression { get; set; }

        public PagerModel(int totalItems, int currentPage, int pageSize = 10)
        {
            this.TotalItems = totalItems;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;

            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            TotalPages = totalPages;

            int startPage = CurrentPage - 5;

            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                    startPage = endPage - 9;
            }
            StartRecord = (CurrentPage - 1) * PageSize + 1;

            EndRecord = StartRecord - 1 + PageSize;

            if (EndRecord > TotalItems)
                EndRecord = TotalItems;

            if (TotalItems == 0)
            {
                StartPage = 0;
                StartRecord = 0;
                CurrentPage = 0;
                EndRecord = 0;
            }
            else
            {
                StartPage = startPage;
                EndPage = endPage;
            }
        }

        public List<SelectListItem> GetPageSize()
        {
            var pageSize = new List<SelectListItem>();

            for (int  i = 10; i <= 50; i += 10)
            {
                if ( 1 == this.PageSize)
                {
                    pageSize.Add(new SelectListItem(i.ToString(), i.ToString(), true));
                }
                else
                {
                    pageSize.Add(new SelectListItem(i.ToString(), i.ToString()));
                }
            }
            return pageSize;
        }

    }
}
