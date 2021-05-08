using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("disciplina")]
    public class Disciplina
    {
        [Column("cod_disciplina")]
        public long id { get; set; }
        public string disciplina { get; set; }
    }
}
