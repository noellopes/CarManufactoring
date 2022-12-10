namespace CarManufactoring.ViewModels
{
    public class PagingInfoViewModel
    {
        public const int Pages_Show_Before_After = 3;
        
        public PagingInfoViewModel(int totalItems, int currentPage, int pageSize = 5 )
        {
            TotalItems= totalItems;
            PageSize= pageSize;

            if (currentPage < 1)
            {
                currentPage=1;
            } else if (currentPage > TotalPages)
            {
                currentPage= TotalPages;
            }

            CurrentPage= currentPage;
        }
        
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public int InitialPageToShow
        {
            get
            {
                int initialPage = CurrentPage - Pages_Show_Before_After;
                return initialPage < 1 ? 1 : initialPage;
            }
        }

        public int FinalPageToShow
        {
            get
            {
                int finalPage = CurrentPage + Pages_Show_Before_After;
                return finalPage > TotalPages ? TotalPages : finalPage;
            }
        }

    }
}
