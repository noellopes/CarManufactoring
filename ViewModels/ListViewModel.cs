
﻿namespace CarManufactoring.ViewModels
{
    public class ListViewModel<T>
    {
        public IEnumerable<T> List { get; set; }
        public PagingInfoViewModel PagingInfo { get; set; }

    }
}
