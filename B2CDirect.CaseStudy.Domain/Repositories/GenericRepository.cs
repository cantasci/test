namespace B2CDirect.CaseStudy.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using B2CDirect.CaseStudy.Domain.Infrastructure;
    using Dapper;
    using DapperExtensions; 
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public IConnectionFactory connectionFactory;

        public GenericRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
 

        public async Task<TEntity> Add(TEntity entity)
        {
            using (var connection = this.connectionFactory.GetConnection)
            {
                var result = await connection.InsertAsync<TEntity>(entity);
                return result;
            }
        }

        public async Task<int> CountAll()
        {
            using (var connection = this.connectionFactory.GetConnection)
            {
                var result = await connection.CountAsync<TEntity>();
                return result;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using (var connection = this.connectionFactory.GetConnection)
            {
                var result = await connection.DeleteAsync<TEntity>(entity);
                return result;
            }
        }

        public Task<TEntity> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
