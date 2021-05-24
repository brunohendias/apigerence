using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("bimestre")]
    public class Bimestre
    {
        public long id { get; set; }
        [Required, MaxLength(45)]
        public string bimestre { get; set; }
    }
}
