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
        [Required, ForeignKey("Serie")]
        public long cod_serie { get; set; }
        [Required, ForeignKey("Turno")]
        public long cod_turno { get; set; }
        [Required, ForeignKey("Turma")]
        public long cod_turma { get; set; }
        [ForeignKey("Professor")]
        public long cod_prof { get; set; }

        public virtual Serie Serie { get; set; }
        public virtual Turno Turno { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Professor Professor { get; set; }

    }
}
