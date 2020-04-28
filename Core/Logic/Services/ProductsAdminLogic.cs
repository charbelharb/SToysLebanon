using Core.Model;
using Data;
using System;
using System.Threading.Tasks;

namespace Core.Logic
{
    public class ProductsAdminLogic : IProductsAdminLogic
    {
        private readonly Context _context;

        private readonly string _product;

        public ProductsAdminLogic(string connectionString, string productPath)
        {
            _context = ContextFactory.GetContext(connectionString);
            _product = productPath;
        }

        public async Task<ApiResponseModel> AddProduct(ProductModel product)
        {
            ApiResponseModel result = new ApiResponseModel
            {
                Type = ResponseType.Success,
                Message = "Product Added"
            };
            try
            {
                await _context.AddAsync(new Product()
                {
                    Notes = product.Notes,
                    Gender = product.Gender,
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ResizedImagePath = product.ResizedImagePath
                });
            }
            catch (Exception ex)
            {
                result.Type = ResponseType.Error;
                result.Message = $"Error Adding Product. {ex.Message}";
            }
            return result;
        }
    }
}
