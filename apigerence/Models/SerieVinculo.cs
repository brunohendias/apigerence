using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie_v")]
    public class SerieVinculo
    {
        [Key]
        public long cod_serie_v { get; set; }
        public int qtd_alunos { get; set; }
        public int limite_alunos { get; set; }
        public long cod_serie { get; set; }
        public long cod_turno { get; set; }
        public long cod_turma { get; set; }
        public long cod_prof { get; set; }

        [ForeignKey("cod_serie")]
        public Serie Serie { get; set; }

        [ForeignKey("cod_turno")]
        public Turno Turno { get; set; }

        [ForeignKey("cod_turma")]
        public Turma Turma { get; set; }

        [ForeignKey("cod_prof")]
        public Professor Professor { get; set; }

    }
}
