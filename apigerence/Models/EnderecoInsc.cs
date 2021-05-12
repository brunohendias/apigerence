using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("endereco_insc")]
    public class EnderecoInsc
    {
        [Key]
        public long cod_endereco_insc { get; set; }
        public long cod_insc { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string cep { get; set; }

        [ForeignKey("cod_insc")]
        public Inscricao Inscricao { get; set; }
    }
}
