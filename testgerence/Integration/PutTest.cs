using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class PutTest : BaseClass
    {
        [Theory,
            InlineData("Turno", "{ 'cod_turno': 1, 'turno': 'teste' }"),
            InlineData("Turma", "{ 'cod_turma': 1, 'turma': 'teste' }"),
            InlineData("Serie", "{ 'cod_serie': 1, 'serie': 'teste' }"),
            InlineData("Disciplina", "{ 'cod_disciplina': 1, 'disciplina': 'teste' }"),
            InlineData("Professor", "{ 'cod_prof': 1, 'nom_prof': 'teste' }"),
            InlineData("SituacaoAluno", "{ 'cod_situacao': 2, 'situacao': 'teste' }"),
            InlineData("Atencao", "{ 'cod_atencao': 1, 'atencao': 'teste' }")
        ]
        public async Task Success (string path, string request = null)
        {
            request = request.Replace("'", "\"");

            StringContent data = new(request, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PutAsync(Pathbase + path, data);

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.False(response.Content == null);

            Assert.Equal(ContentType,
                response.Content.Headers.ContentType.ToString());

            string result = await response.Content.ReadAsStringAsync();

            Assert.False(result.Length == 0);

            if (request != null)
                Assert.Contains(request.Replace(" ", ""), result);
        }
    }
}
