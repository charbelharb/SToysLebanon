using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Tests
{
    public class ProductsControllerTest : IntegrationTestBase
    {
        [Fact]
        public async Task Get_All_Categories()
        {
            var response = await _client.GetAsync("/api/Products/GetCategories");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Get_All_Brands()
        {
            var response = await _client.GetAsync("/api/Products/GetBrands");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
