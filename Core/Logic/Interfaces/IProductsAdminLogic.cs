using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IProductsAdminLogic
    {
        Task<ApiResponseModel> AddProduct(ProductModel product);

        Task<IList<BrandsModel>> GetBrands();

        Task<IList<CategoriesModel>> GetCategories();

    }
}
