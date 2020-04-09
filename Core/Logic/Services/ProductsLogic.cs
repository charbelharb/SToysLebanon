using Core.Model;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic
{
    public class ProductsLogic : IProductsLogic
    {
        private readonly Context _context;

        public ProductsLogic(string connectionString)
        {
            _context = ContextFactory.GetContext(connectionString);
        }
        public async Task<PaginatorResponse<ProductModel>> GetProducts(ProductSearchModel searchParams)
        {
            PaginatorResponse<ProductModel> result = new PaginatorResponse<ProductModel>();
            using (_context)
            {
                var query = _context.Products.AsQueryable();
                if (searchParams.Gender > 0 && searchParams.Gender < 3)
                {
                    query = query.Where(x => x.Gender == (Gender)searchParams.Gender);
                }
                if (searchParams.Age > 0 && searchParams.Age < 6)
                {
                    query = query.Where(x => x.Age == (Age)searchParams.Age);
                }
                if (searchParams.Category > 0 && searchParams.Category < 3)
                {
                    query = query.Where(x => x.Category == (Category)searchParams.Category);
                }
                if(!string.IsNullOrEmpty(searchParams.SearchText))
                {
                    query = query.Where(x => x.Name.Contains(searchParams.SearchText) || x.Description.Contains(searchParams.SearchText));
                }
                result.PaginatorModel.Total = await query.CountAsync();
                query = query.Skip(searchParams.PageIndex * searchParams.PageSize).Take(searchParams.PageSize);
                if (searchParams.SortBy == 1)
                {
                    query = searchParams.Direction == 1 ? query.OrderBy(x => x.Price) : query.OrderByDescending(x => x.Price);
                }
                else if (searchParams.SortBy == 2)
                {
                    query = searchParams.Direction == 1 ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
                }
                else
                {
                    query = searchParams.Direction == 1 ? query.OrderBy(x => x.Price) : query.OrderByDescending(x => x.Price);
                }
                result.PaginatorModel.Data = await query.Select(x => new ProductModel()
                {
                    Age = x.Age,
                    Category = x.Category,
                    Description = x.Description,
                    Gender = x.Gender,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Name = x.ImagePath,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    ResizedImagePath = x.ResizedImagePath
                }).ToListAsync();
                return result;
            }
        }
    }
}
