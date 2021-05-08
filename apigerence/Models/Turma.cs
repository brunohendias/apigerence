using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("turma")]
    public class Turma
    {
        [Column("cod_turma")]
        public long id { get; set; }
        public string turma { get; set; }
    }
}
