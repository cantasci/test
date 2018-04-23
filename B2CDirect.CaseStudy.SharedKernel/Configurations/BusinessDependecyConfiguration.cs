
namespace B2CDirect.CaseStudy.SharedKernel.Configurations
{
    using AutoMapper;
    using B2CDirect.CaseStudy.Business.Services;
    using B2CDirect.CaseStudy.Common.Models.Product;
    using B2CDirect.CaseStudy.Domain.Entities;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessDependecyConfiguration
    {

        public static void ConfigureBusiness(this IServiceCollection services){
            services.AddTransient<IProductService, ProductService>();


            Mapper.Initialize(cfg => {
                cfg.CreateMap<Product, ProductOutputModel>(); 
            });
        }
    }
}
