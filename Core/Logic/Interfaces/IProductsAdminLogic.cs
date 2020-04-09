using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic
{
    public interface IProductsAdminLogic
    {
        Task<ApiResponseModel> AddProduct(ProductModel product);

        Task<string> GenerateMock();
    }
}
