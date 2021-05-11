using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("aluno_disciplina")]
    public class AlunoDisciplina
    {
        [Column("cod_aluno_disc")]
        public long id { get; set; }
        public decimal nota { get; set; }
        public long cod_aluno { get; set; }
        public long cod_serie_disc { get; set; }
        public long cod_serie { get; set; }
        public long cod_disciplina { get; set; }
        public long cod_bimestre { get; set; }
    }
}
