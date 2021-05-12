using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("situacao_aluno")]
    public class SituacaoAluno
    {
        [Key]
        public long cod_situacao { get; set; }
        [Required]
        [MaxLength(50)]
        public string situacao { get; set; }
    }
}
