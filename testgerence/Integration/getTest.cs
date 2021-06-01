using apigerence.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
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
            Theory, InlineData("Turno"), 
            InlineData("Turma"), InlineData("Serie"),
            InlineData("Disciplina"), InlineData("Professor"),
            InlineData("SituacaoAluno"), InlineData("Atencao"),
            InlineData("Inscricao"), InlineData("Candidato"), 
            InlineData("Aluno"), InlineData("DadosSerie"), 
            InlineData("AlunoDisciplina"), InlineData("SerieDisciplina")
        ]
        public async Task Check_if_success (string url)
        {
            HttpResponseMessage response = await client.GetAsync("/api/v1/" + url);

            // Status Code 200-299
            response.EnsureSuccessStatusCode();

            // Verifica o Header (tipo de retorno)
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.False(response.Content == null);

            // Pega os dados de retorno
            string stringResponse = await response.Content.ReadAsStringAsync();
            
            // Verifica se encontrou resultado
            Assert.False(stringResponse.Length == 0);

            if (url == "Atencao")
            { // Exemplos
                List<Atencao> json = JsonConvert.DeserializeObject<List<Atencao>>(stringResponse);
                Assert.True(json.Count > 0);
                Assert.True(json[0].cod_atencao == 1);
            }
        }
    }
}
