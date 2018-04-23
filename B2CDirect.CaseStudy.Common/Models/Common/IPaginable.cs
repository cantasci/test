namespace B2CDirect.CaseStudy.Common.Models.Common
{
    public interface IPaginable
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }
    }
}
