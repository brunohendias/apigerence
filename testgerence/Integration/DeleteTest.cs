using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class DeleteTest : IClassFixture<WebApplicationFactory<apigerence.Startup>>
    {
        private readonly HttpClient client;

        private static readonly string pathbase = "/api/v1/";

        public DeleteTest(WebApplicationFactory<apigerence.Startup> factory) =>
           client = factory.CreateClient();

        [
            InlineData("Turno/1"),
            InlineData("Turma/1"),
            InlineData("Serie/1"),
            InlineData("Disciplina/1"),
            InlineData("Professor/1"),
            InlineData("SituacaoAluno/1"),
            InlineData("Atencao/1")
        ]
        public async Task Success (string path)
        {
            HttpResponseMessage response = await client.DeleteAsync(pathbase + path);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}
