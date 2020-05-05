using Core;
using Core.Model;
using Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Tests
{
    public abstract class IntegrationTestBase
    {
        protected readonly HttpClient _client;

        protected IntegrationTestBase()
        {
            WebApplicationFactory<Startup> apiFactory = new WebApplicationFactory<Startup>();
            _client = apiFactory.CreateClient();
        }

        [Fact]
        public async Task Login_Default_Username()
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("/api/Auth/LogIn", new LoginModel()
            {
                Email = "s@scorz.org",
                Password = "admin"
            });
            string content = await response.Content.ReadAsStringAsync();
            AuthResponseModel responseModel = JsonConvert.DeserializeObject<AuthResponseModel>(content);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", responseModel.Token);
            Assert.NotNull(responseModel.Token);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
