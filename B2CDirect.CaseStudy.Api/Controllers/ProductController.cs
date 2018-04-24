namespace B2CDirect.CaseStudy.Api.Controllers
{
    using System.Threading.Tasks;
    using B2CDirect.CaseStudy.Business.Services;
    using B2CDirect.CaseStudy.Common.Models.Product;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/products")]
    [EnableCors("AllowAnyOrigin")]
    public class ProductController : Controller
    {

        IProductService productService; 

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> GetAllProductByPageIndex(ProductGetInputModel inputModel)
        {
            var resultData = await productService.GetAllProductByPageIndex(inputModel);
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

    }
}
