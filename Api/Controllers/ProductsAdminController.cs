using Core;
using Core.Logic;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsAdminController : ApiBaseController
    {
        private readonly IProductsAdminLogic _productsAdminLogic;

        public ProductsAdminController(IProductsAdminLogic productsAdminLogic)
        {
            _productsAdminLogic = productsAdminLogic;
        }

        [HttpPost]
        [ApiAuthorize]
        public async Task<ApiResponseModel> AddProduct(ProductModel product)
        {
            return await _productsAdminLogic.AddProduct(product);
        }

        [HttpGet]
        [ApiAuthorize]
        public async Task<IList<CategoriesModel>> GetCategories()
        {
            return await _productsAdminLogic.GetCategories();
        }

        [HttpGet]
        [ApiAuthorize]
        public async Task<IList<BrandsModel>> GetBrands()
        {
            return await _productsAdminLogic.GetBrands();
        }
    }
}