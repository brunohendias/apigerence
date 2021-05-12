using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("endereco_insc")]
    public class EnderecoInsc
    {
        [Key]
        public long cod_endereco_insc { get; set; }
        [Required]
        public long cod_insc { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public string cidade { get; set; }
        [Required]
        public string bairro { get; set; }
        [Required]
        public string rua { get; set; }
        [Required]
        public int numero { get; set; }
        public string cep { get; set; }

        [ForeignKey("cod_insc")]
        public Inscricao Inscricao { get; set; }
    }
}
