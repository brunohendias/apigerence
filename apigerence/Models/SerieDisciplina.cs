using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie_disciplina")]
    public class SerieDisciplina
    {
        [Key]
        public long cod_serie_disc { get; set; }
        public long cod_serie { get; set; }
        public long cod_disciplina { get; set; }

        [ForeignKey("cod_serie")]
        public Serie Serie { get; set; }

        [ForeignKey("cod_disciplina")]
        public Disciplina Disciplina { get; set; }
    }
}
