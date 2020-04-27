using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IProductsLogic
    {
        Task<PaginatorResponse<ProductResponseModel>> GetProducts(ProductSearchModel searchParams, bool checkSize = true);

        Task<IList<SelectModel>> GetBrands();

        Task<IList<SelectModel>> GetCategories();

    }
}
