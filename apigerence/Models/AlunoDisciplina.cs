using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("aluno_disciplina")]
    public class AlunoDisciplina
    {
        [Key]
        public long cod_aluno_disc { get; set; }
        [Required]
        public float nota { get; set; }
        [Required]
        [ForeignKey("Aluno")]
        public long cod_aluno { get; set; }
        [Required]
        [ForeignKey("SerieDisciplina")]
        public long cod_serie_disc { get; set; }
        [Required]
        [ForeignKey("Bimestre")]
        public long cod_bimestre { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual SerieDisciplina SerieDisciplina { get; set; }
        public virtual Bimestre Bimestre { get; set; }
    }
}
