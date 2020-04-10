using Core.Model;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IProductsLogic
    {
        Task<PaginatorResponse<ProductResponseModel>> GetProducts(ProductSearchModel searchParams);
    }
}
