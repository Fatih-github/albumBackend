using System;
using Xunit;
using System.Collections.Generic;
using System.Net.Http;  
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Album.Api.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<Models.SimpleModelsAndRelationsContext>));

                services.Remove(descriptor);

                services.AddDbContext<Models.SimpleModelsAndRelationsContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                // Build the service provider.
                services.BuildServiceProvider();
            });
        }
    }
    public class AlbumControllerTest
    {
        public class IntegratieTest : IClassFixture<CustomWebApplicationFactory<Startup>>
        {
            private readonly HttpClient _client;
            public CustomWebApplicationFactory<Startup> _factory;
            public IntegratieTest(CustomWebApplicationFactory<Startup> factory) {
                _client = factory.CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
                _factory = factory;
            }

            [Fact]
            public async Task TestGetAllAlbums()
            {
                // Arrange
                var request = "http://localhost:5000/api/album";

                // Act
                var response = await _client.GetAsync(request);

                // Assert
                response.EnsureSuccessStatusCode();

                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            }

            [Fact]
            public async Task TestCreateAlbum()
            {
                // Arrange
                var request = "http://localhost:5000/api/album";
                var payload = "{\"Id\": 3,\"Name\": \"kees\", \"Artist\": \"Klaas\", \"ImageUrl\": \"232.com\"}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                // Act
                var response = await _client.PostAsync(request, content);

                // Assert
                response.EnsureSuccessStatusCode();

                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            }

            [Fact]
            public async Task TestUpdateAlbum()
            {
                var request = "http://localhost:5000/api/album/4";
                var payload = "{\"Id\": 3,\"Name\": \"Jan\", \"Artist\": \"Peter\", \"ImageUrl\": \"111.com\"}";
                
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(request, content);

                // Assert
                response.EnsureSuccessStatusCode();

                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            }

            [Fact]
            public async Task TestDeleteAlbum()
            {
                var request = new HttpRequestMessage {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:5000/api/album/3")
                };
                var response = await _client.SendAsync(request);

                // Assert
                response.EnsureSuccessStatusCode();

                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
