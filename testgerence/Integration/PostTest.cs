using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class PostTest : BaseClass
    {
        [Theory,
            InlineData("Turno", "{ 'turno': 'teste' }"),
            InlineData("Turma", "{ 'turma': 'teste' }"),
            InlineData("Serie", "{ 'serie': 'teste' }"),
            InlineData("Disciplina", "{ 'disciplina': 'teste' }"),
            InlineData("Professor", "{ 'nom_prof': 'teste' }"),
            InlineData("SituacaoAluno", "{ 'situacao': 'teste' }"),
            InlineData("Atencao", "{ 'atencao': 'teste' }")
        ]
        public async Task Success (string path, string request = null)
        {
            request = request.Replace("'", "\"");

            StringContent data = new(request, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync(Pathbase + path, data);

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.False(response.Content == null);

            Assert.Equal(ContentType,
                response.Content.Headers.ContentType.ToString());

            string result = await response.Content.ReadAsStringAsync();

            Assert.False(result.Length == 0);

            if (request != null)
            {
                request = request.Replace("{ ", "").Replace(" }", "").Replace(" ", "");
                Assert.Contains(request, result);
            }
        }
    }
}
