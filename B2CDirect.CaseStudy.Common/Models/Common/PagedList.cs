namespace B2CDirect.CaseStudy.Common.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PagedList<T>
    {  
        public List<T> Sources { get; set; } = new List<T>();
         
        public int CurrentPage { get; private set; }
         
        public int TotalPages { get; private set; }
         
        public int PageSize { get; private set; }
         
        public int TotalCount { get; private set; }
         
        public bool HasPrevious => (CurrentPage > 0);

        public bool HasNext => (CurrentPage < TotalPages-1);

         
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Sources.AddRange(items);
        } 
    }
}
