namespace B2CDirect.CaseStudy.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using B2CDirect.CaseStudy.Domain.Entities;
    using B2CDirect.CaseStudy.Domain.Infrastructure;
    using DapperExtensions;
    using System.Text;

    using Dapper.FastCrud;
    using Dapper.FastCrud.Configuration.StatementOptions.Builders;
    using B2CDirect.CaseStudy.Common.Models.Common;

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IConnectionFactory connectionFactory)
                    : base(connectionFactory)
        {
        }

        public async Task<PagedList<Product>> GetAllProdcutByPageIndexAsync(string term, int pageIndex, int pageSize = 50)
        {
            using (var connection = this.connectionFactory.GetConnection)
            {
                var predicateGroup = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

                if (!string.IsNullOrEmpty(term))
                    predicateGroup.Predicates.Add(Predicates.Field<Product>(p => p.Name, Operator.Like, term));


                term = $"%{term ?? string.Empty}%";
                

                var source = await connection.FindAsync<Product>(statement => statement
                                 .Where($"{nameof(Product.Name):C} LIKE @term")
                                 .OrderBy($"{nameof(Product.Id):C} ASC")
                                 .Skip(pageIndex * pageSize)
                                 .Top(pageSize)
                                 .WithParameters(new { term = term ?? string.Empty }));

                var count = await connection.CountAsync<Product>(statement => statement
                                .Where($"{nameof(Product.Name):C} LIKE @term") 
                                .WithParameters(new { term = term ?? string.Empty }));


                return new PagedList<Product>(source.ToList(), count, pageIndex, pageSize);
            }
        }
    }
}
