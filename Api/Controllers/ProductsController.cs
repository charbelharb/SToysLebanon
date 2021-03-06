﻿using Core;
using Core.Logic;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ApiBaseController
    {
        private readonly IProductsLogic _productsLogic;

        public ProductsController(IProductsLogic productsLogic)
        {
            _productsLogic = productsLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<PaginatorResponse<ProductResponseModel>> GetProducts([FromBody]ProductSearchModel searchParams)
        {
            return await _productsLogic.GetProducts(searchParams);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IList<SelectModel>> GetCategories()
        {
            return await _productsLogic.GetCategories();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IList<SelectModel>> GetBrands()
        {
            return await _productsLogic.GetBrands();
        }
    }
}