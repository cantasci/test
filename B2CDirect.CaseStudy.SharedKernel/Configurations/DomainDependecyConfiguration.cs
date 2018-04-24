namespace B2CDirect.CaseStudy.SharedKernel.Configurations
{
    using B2CDirect.CaseStudy.Domain.Infrastructure;
    using B2CDirect.CaseStudy.Domain.Repositories;

    using Dapper.FastCrud;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;


    public static class DomainDependecyConfiguration
    {
        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>(
                serviceProvider => {
                    var connectionString = serviceProvider.GetService<IConfiguration>().GetConnectionString("Demo");
                    return new ConnectionFactory(connectionString);
                } 
            );
            services.AddTransient<IProductRepository, ProductRepository>();

            OrmConfiguration.DefaultDialect = SqlDialect.SqLite;
        }
    }
}
