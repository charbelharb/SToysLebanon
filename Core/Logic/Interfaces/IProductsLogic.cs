using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IProductsLogic
    {
        Task<PaginatorResponse<ProductModel>> GetProducts(ProductSearchModel searchParams);
    }
}
