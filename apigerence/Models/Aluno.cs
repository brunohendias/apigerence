using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("aluno")]
    public class Aluno
    {
        [Key]
        public long cod_aluno { get; set; }
        [Required]
        [MaxLength(50)]
        public string nome { get; set; }
        [Required]
        [MaxLength(10)]
        public string num_matricula { get; set; }
        [Required]
        [ForeignKey("Candidato")]
        public long cod_can { get; set; }
        [Required]
        [ForeignKey("SerieVinculo")]
        public long cod_serie_v { get; set; }
        [Required]
        [ForeignKey("Atencao")]
        public long cod_atencao { get; set; }
        [Required]
        [ForeignKey("Situacao")]
        public long cod_situacao { get; set; }

        public Candidato Candidato { get; set; }
        public SerieVinculo SerieVinculo { get; set; }
        public Atencao Atencao { get; set; }
        public SituacaoAluno Situacao { get; set; }

    }
}
