using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("aluno")]
    public class Aluno
    {
        [Key]
        public long cod_aluno { get; set; }
        public string nom_aluno { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string num_matricula { get; set; }
        public long cod_can { get; set; }
        public long cod_serie_v { get; set; }
        public long cod_atencao { get; set; }
        public long cod_situacao { get; set; }

        [ForeignKey("cod_can")]
        public Candidato Candidato { get; set; }
        [ForeignKey("cod_serie_v")]
        public SerieVinculo InfosSerie { get; set; }
        [ForeignKey("cod_atencao")]
        public Atencao Atencao { get; set; }
        [ForeignKey("cod_situacao")]
        public SituacaoAluno Situacao { get; set; }

    }
}
