using Core.Model;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Logic
{
    public class ProductsAdminLogic : LogicBase, IProductsAdminLogic
    {
        public ProductsAdminLogic(Context context) : base(context)
        {
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

        public async Task<IList<BrandsModel>> GetBrands()
        {
            return await _context.Brands.Select(x => new BrandsModel() { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public async Task<IList<CategoriesModel>> GetCategories()
        {
            return await _context.Categories.Select(x => new CategoriesModel() { Id = x.Id, Name = x.Name }).ToListAsync();
        }
    }
}
