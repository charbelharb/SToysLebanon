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

#if DEBUG
        // generate mock dev only

        public async Task<string> GenerateMock()
        {
            await _context.Products.AddRangeAsync(new Product()
            {
                Age = Age.SevenToTen,
                Category = Category.Dolls,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Gender = Gender.Girl,
                ImagePath = "b1.jpg",
                Name = "Barbie 1",
                Price = 25000,
                Quantity = 3,
                ResizedImagePath = "b1-small.jpg"
            }, new Product()
            {
                Age = Age.TenToThirteen,
                Category = Category.Dolls,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Gender = Gender.Girl,
                ImagePath = "b2.jpg",
                Name = "Barbie 2",
                Price = 35000,
                Quantity = 0,
                ResizedImagePath = "b2-small.jpg"
            }, new Product()
            {
                Age = Age.SevenToTen,
                Category = Category.Dolls,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Gender = Gender.Girl,
                ImagePath = "b3.jpg",
                Name = "Barbie 3",
                Price = 40000,
                Quantity = 5,
                ResizedImagePath = "b3-small.jpg"
            }, new Product()
            {
                Age = Age.SevenToTen,
                Category = Category.Cars,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Gender = Gender.Boy,
                ImagePath = "c1.jpg",
                Name = "Car 1",
                Price = 10000,
                Quantity = 10,
                ResizedImagePath = "c1-small.jpg"
            }, new Product()
            {
                Age = Age.ThirteenPlus,
                Category = Category.Cars,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Gender = Gender.Boy,
                ImagePath = "c2.jpg",
                Name = "Car 2",
                Price = 50000,
                Quantity = 0,
                ResizedImagePath = "c2-small.jpg"
            });
            await _context.SaveChangesAsync();
            return "ok";
        }
#endif
    }
}
