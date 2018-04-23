namespace B2CDirect.CaseStudy.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;
 
    using B2CDirect.CaseStudy.Domain.Entities;
    using B2CDirect.CaseStudy.Domain.Infrastructure;
    using DapperExtensions;
    using System.Text;

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IConnectionFactory connectionFactory) 
                    : base(connectionFactory)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProdcutByPageIndexAsync(string term, int pageIndex, int pageSize = 50)
        {
            using (var connection = this.connectionFactory.GetConnection)
            {
                var predicateGroup = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

                if(!string.IsNullOrEmpty(term))
                    predicateGroup.Predicates.Add(Predicates.Field<Product>(p => p.Name, Operator.Like, term));
                
                return await connection.GetPageAsync<Product>(
                    predicate: predicateGroup,
                    sort: new List<ISort> { Predicates.Sort<Product>(p => p.Id)}
                );
            }

          
        }
    }
}
