using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie_disciplina")]
    public class SerieDisciplina
    {
        [Column("cod_serie_disc")]
        public long id { get; set; }
        public long cod_serie { get; set; }
        public long cod_disciplina { get; set; }
    }
}
