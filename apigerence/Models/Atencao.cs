using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("atencao")]
    public class Atencao
    {
        [Column("cod_atencao")]
        public long id { get; set; }
        public string atencao { get; set; }
    }
}
