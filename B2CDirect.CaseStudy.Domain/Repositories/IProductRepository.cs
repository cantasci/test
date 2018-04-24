namespace B2CDirect.CaseStudy.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using B2CDirect.CaseStudy.Common.Models.Common;
    using B2CDirect.CaseStudy.Domain.Entities;

    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagedList<Product>> GetAllProdcutByPageIndexAsync(string term, int pageIndex, int pageSize=50);
    }
}
