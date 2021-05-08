using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie")]
    public class Serie
    {
        [Column("cod_serie")]
        public long id { get; set; }
        public string serie { get; set; }
    }
}
