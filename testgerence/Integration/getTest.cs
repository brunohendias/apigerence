using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class GetTest : IClassFixture<WebApplicationFactory<apigerence.Startup>>
    {
        private readonly HttpClient client;

        private static readonly string pathbase = "/api/v1/";

        public GetTest(WebApplicationFactory<apigerence.Startup> factory) => 
            client = factory.CreateClient();

        [
            Theory,
            InlineData("Turno", "cod_turno: 1"),
            InlineData("Turma", "cod_turma: 1"),
            InlineData("Serie", "cod_serie: 1"),
            InlineData("Disciplina", "cod_disciplina: 1"),
            InlineData("Professor", "cod_prof: 1"),
            InlineData("SituacaoAluno", "cod_situacao: 1"),
            InlineData("Atencao", "cod_atencao: 1"),
            InlineData("Inscricao"),
            InlineData("Candidato", "cod_can: 2"),
            InlineData("Aluno", "cod_aluno: 5"),
            InlineData("DadosSerie"),
            InlineData("AlunoDisciplina", "cod_aluno: 5"),
            InlineData("SerieDisciplina")
        ]
        public async Task Check_if_success (string url, string request = null)
        {
            HttpResponseMessage response = await client.GetAsync(pathbase + url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.False(response.Content == null);

            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            string result = await response.Content.ReadAsStringAsync();

            Assert.False(result.Length == 0);

            if (request != null)
            {
                Assert.Contains(request, result.Replace("\"", "").Replace(":", ": "));
            }
        }
    }
}