namespace B2CDirect.CaseStudy.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using B2CDirect.CaseStudy.Domain.Entities;

    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProdcutByPageIndexAsync(string term, int pageIndex, int pageSize=50);
    }
}
