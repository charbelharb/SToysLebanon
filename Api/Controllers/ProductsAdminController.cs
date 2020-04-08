using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Logic;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsAdminController : ApiBaseController
    {
        private IProductsAdminLogic _productsAdminLogic;

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

    }
}