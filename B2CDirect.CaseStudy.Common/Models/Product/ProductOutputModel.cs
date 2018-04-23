using System;
namespace B2CDirect.CaseStudy.Common.Models.Product
{
    public class ProductOutputModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
    }
}
