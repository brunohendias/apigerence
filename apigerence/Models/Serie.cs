using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie")]
    public class Serie
    {
        [Key]
        public long cod_serie { get; set; }
        public string serie { get; set; }
    }
}
