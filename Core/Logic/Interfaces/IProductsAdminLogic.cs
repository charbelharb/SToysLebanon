using Core.Model;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IProductsAdminLogic
    {
        Task<ApiResponseModel> AddProduct(ProductModel product);

    }
}
