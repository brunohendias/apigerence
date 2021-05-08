using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("situacao_aluno")]
    public class SituacaoAluno
    {
        [Column("cod_situacao")]
        public long id { get; set; }
        public string situacao { get; set; }
    }
}
