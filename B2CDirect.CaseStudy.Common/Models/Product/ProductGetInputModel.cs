namespace B2CDirect.CaseStudy.Common.Models.Product
{
    using System;
    using B2CDirect.CaseStudy.Common.Models.Common;

    public class ProductGetInputModel : ISearchable, IPaginable
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Term { get; set; }
    }
}
