using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Logic;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ApiBaseController
    {
        private IProductsLogic _productsLogic;

        public ProductsController(IProductsLogic productsLogic)
        {
            _productsLogic = productsLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<PaginatorResponse<ProductModel>> GetProducts([FromBody]ProductSearchModel searchParams) => await _productsLogic.GetProducts(searchParams);
    }
}