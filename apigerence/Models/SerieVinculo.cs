using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie_v")]
    public class SerieVinculo
    {
        [Key]
        public long cod_serie_v { get; set; }
        [Required]
        public int qtd_alunos { get; set; }
        [Required]
        public int limite_alunos { get; set; }
        [Required]
        public long cod_serie { get; set; }
        [Required]
        public long cod_turno { get; set; }
        [Required]
        public long cod_turma { get; set; }
        public long cod_prof { get; set; }

        [ForeignKey("cod_serie")]
        public virtual Serie Serie { get; set; }

        [ForeignKey("cod_turno")]
        public virtual Turno Turno { get; set; }

        [ForeignKey("cod_turma")]
        public virtual Turma Turma { get; set; }

        [ForeignKey("cod_prof")]
        public virtual Professor Professor { get; set; }

    }
}
