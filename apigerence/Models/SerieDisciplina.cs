using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie_disciplina")]
    public class SerieDisciplina
    {
        [Key]
        public long cod_serie_disc { get; set; }
        [Required, ForeignKey("Serie")]
        public long cod_serie { get; set; }
        [Required, ForeignKey("Disciplina")]
        public long cod_disciplina { get; set; }

        public Serie Serie { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
