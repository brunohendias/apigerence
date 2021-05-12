using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("atencao")]
    public class Atencao
    {
        [Key]
        public long cod_atencao { get; set; }
        public string atencao { get; set; }
    }
}
