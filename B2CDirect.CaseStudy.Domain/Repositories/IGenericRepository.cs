namespace B2CDirect.CaseStudy.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<int> CountAll();
    }
}
