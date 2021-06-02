using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class GetTest : IClassFixture<WebApplicationFactory<apigerence.Startup>>
    {
        private readonly HttpClient client;

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
        public async Task Check_if_success (string url, string result = null)
        {
            HttpResponseMessage response = await client.GetAsync("/api/v1/" + url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.False(response.Content == null);

            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            string stringResponse = await response.Content.ReadAsStringAsync();

            Assert.False(stringResponse.Length == 0);

            if (result != null)
            {
                Assert.Contains(result, stringResponse.Replace("\"", "").Replace(":", ": "));
            }
        }
    }
}

/*if (url == "Atencao")// Exemplos
{
    List<Atencao> json = JsonConvert.DeserializeObject<List<Atencao>>(stringResponse);
    Assert.True(json.Count > 0);
    Assert.True(json[0].cod_atencao == 1);
}*/
