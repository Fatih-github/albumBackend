using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Album.Api.IntegratieTests
{
    public class UnitTest1
    {
        public class IntegratieTest
        {
            private readonly HttpClient _client;
            public IntegratieTest() {
                _client = new HttpClient();
            }

            [Fact]
            public async Task TestGetStockItemsAsync()
            {
                // Arrange
                var request = "https://localhost:5001/api/hello/qwe";

                // Act
                var response = await _client.GetAsync(request);

                // Assert
                response.EnsureSuccessStatusCode();

                Assert.Equal("Created new album succesfully", response.ToString());
            }
        }
    }
}
