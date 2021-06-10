using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace testgerence.Integration
{
    public class DeleteTest : BaseClass
    {
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
            HttpResponseMessage response = await Client.DeleteAsync(Pathbase + path);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}
