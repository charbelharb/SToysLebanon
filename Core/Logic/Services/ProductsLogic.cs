using Core.Model;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Logic
{
    public class ProductsLogic : LogicBase, IProductsLogic
    {

        public ProductsLogic(Context context):base(context)
        {
        }

        public async Task<IList<SelectModel>> GetBrands()
        {
            return await _context.Brands.Select(x => new SelectModel() { Value = x.Id, ViewValue = x.Name }).ToListAsync();
        }

        public async Task<IList<SelectModel>> GetCategories()
        {
            return await _context.Categories.Select(x => new SelectModel() { Value = x.Id, ViewValue = x.Name }).ToListAsync();
        }

        public async Task<PaginatorResponse<ProductResponseModel>> GetProducts(ProductSearchModel searchParams, bool checkSize = true)
        {
            PaginatorResponse<ProductResponseModel> result = new PaginatorResponse<ProductResponseModel>();
            using (_context)
            {
                IQueryable<Product> query = _context.Products.AsQueryable();
                if (searchParams.Gender > 0 && searchParams.Gender < 3)
                {
                    query = query.Where(x => x.Gender == (Gender)searchParams.Gender || x.Gender == Gender.All);
                }
                if (!string.IsNullOrEmpty(searchParams.SearchText))
                {
                    query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), "%" + searchParams.SearchText.ToLower() + "%"));
                }
                if (searchParams.Brand > 0)
                {
                    query = query.Where(x => x.BrandId == searchParams.Brand);
                }
                if (searchParams.Category > 0)
                {
                    query = query.Where(x => x.CategoryId == searchParams.Category);
                }
                result.PaginatorModel.Total = await query.CountAsync();
                if (searchParams.SortBy == 2)
                {
                    query = searchParams.Direction == 1 ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
                    
                }
                else
                {
                    query = searchParams.Direction == 1 ? query.OrderBy(x => x.Price) : query.OrderByDescending(x => x.Price);
                }
                if(searchParams.PageSize > 6 && checkSize)
                {
                    searchParams.PageSize = 6;
                }
                query = query.Skip(searchParams.PageIndex * searchParams.PageSize).Take(searchParams.PageSize);
                result.PaginatorModel.Data = await query.Select(x => new ProductResponseModel()
                {
                    Notes = x.Notes,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    ResizedImagePath = x.ResizedImagePath,
                    Subtitle = x.Category.Name + (string.IsNullOrEmpty(x.Notes) ? "" : " - " + x.Notes),
                    Brand = x.Brand.Name
                }).ToListAsync();
                return result;
            }
        }


    }
}
