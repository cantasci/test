namespace B2CDirect.CaseStudy.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;

    using B2CDirect.CaseStudy.Common.Models.Common;
    using B2CDirect.CaseStudy.Common.Models.Product;
    using B2CDirect.CaseStudy.Domain.Repositories;

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<PagedList<ProductOutputModel>> GetAllProductByPageIndex(ProductGetInputModel inputModel)
        {
            var productsRoot = await this.productRepository.GetAllProdcutByPageIndexAsync(inputModel.Term, inputModel.PageIndex, inputModel.PageSize);
            var resultProduct = Mapper.Map<List<ProductOutputModel>>(productsRoot.Sources);

            return new PagedList<ProductOutputModel>(
                resultProduct,
                productsRoot.TotalCount,
                productsRoot.CurrentPage,
                productsRoot.PageSize);
        }
    }
}
