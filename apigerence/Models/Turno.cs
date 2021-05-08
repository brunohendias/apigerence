using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("turno")]
    public class Turno
    {
        [Column("cod_turno")]
        public long id { get; set; }
        public string turno { get; set; }
    }
}
