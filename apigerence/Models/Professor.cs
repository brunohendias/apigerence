using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("professor")]
    public class Professor
    {
        [Column("cod_prof")]
        public long id { get; set; }
        public string nom_prof { get; set; }
    }
}
