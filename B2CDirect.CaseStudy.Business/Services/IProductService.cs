namespace B2CDirect.CaseStudy.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using B2CDirect.CaseStudy.Common.Models.Product;

    public interface IProductService
    {
        Task<IEnumerable<ProductOutputModel>> GetAllProductByPageIndex(ProductGetInputModel inputModel);
       
    }
}
