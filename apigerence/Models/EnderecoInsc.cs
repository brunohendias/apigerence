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
        [ForeignKey("Inscricao")]
        public long cod_insc { get; set; }
        [Required]
        [MaxLength(2)]
        public string estado { get; set; }
        [Required]
        [MaxLength(90)]
        public string cidade { get; set; }
        [Required]
        [MaxLength(90)]
        public string bairro { get; set; }
        [Required]
        [MaxLength(90)]
        public string rua { get; set; }
        [Required]
        public int numero { get; set; }
        [MaxLength(8)]
        public string cep { get; set; }

        public Inscricao Inscricao { get; set; }
    }
}
