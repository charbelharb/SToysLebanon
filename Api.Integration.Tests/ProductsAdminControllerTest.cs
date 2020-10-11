using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Tests
{
    public class ProductsAdminControllerTest : IntegrationTestBase
    {
        [Fact]
        public async Task Get_All_Categories_Admin()
        {
            await Authorize();
            System.Net.Http.HttpResponseMessage response = await _client.GetAsync("/api/ProductsAdmin/GetCategories");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Get_All_Brands_Admin()
        {
            await Authorize();
            System.Net.Http.HttpResponseMessage response = await _client.GetAsync("/api/ProductsAdmin/GetBrands");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
