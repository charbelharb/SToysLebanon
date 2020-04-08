using Core.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Services
{
    public class ProducstAdminLogic : IProductsAdminLogic
    {
        private readonly Context _context;

        private readonly string _product;

        public ProducstAdminLogic(string connectionString, string productPath)
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
                    Age = product.Age,
                    Category = product.Category,
                    Description = product.Description,
                    Gender = product.Gender,
                    ImagePath = "",
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    ResizedImagePath = ""
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
