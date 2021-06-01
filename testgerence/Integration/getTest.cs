using apigerence.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class getTest : IClassFixture<WebApplicationFactory<apigerence.Startup>>
    {
        private readonly WebApplicationFactory<apigerence.Startup> _factory;

        public getTest(WebApplicationFactory<apigerence.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("Atencao")]
        [InlineData("Serie")]
        [InlineData("Turma")]
        [InlineData("Turno")]
        public async Task check_if_success_get(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/v1/" + url);

            // Assert
            // Status Code 200-299
            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.False(response.Content == null);

            // pega os dados de retorno
            string stringResponse = await response.Content.ReadAsStringAsync();
            Assert.False(stringResponse.Count() == 0);

            if (url == "Atencao")
            {
                var json = JsonConvert.DeserializeObject<List<Atencao>>(stringResponse);
                Assert.True(json.Count > 0);
                Assert.True(json[0].cod_atencao == 1);
            }
            else if (url == "Serie")
            {
                var json = JsonConvert.DeserializeObject<List<Serie>>(stringResponse);
                Assert.True(json.Count > 0);
                Assert.True(json[0].cod_serie == 1);
            }
            else if (url == "Turma")
            {
                var json = JsonConvert.DeserializeObject<List<Turma>>(stringResponse);
                Assert.True(json.Count > 0);
                Assert.True(json[0].cod_turma == 1);
            }
            else if (url == "Turno")
            {
                var json  = JsonConvert.DeserializeObject<List<Turno>>(stringResponse);
                Assert.True(json.Count > 0);
                Assert.True(json[0].cod_turno == 1);
            }
        }
    }
}
