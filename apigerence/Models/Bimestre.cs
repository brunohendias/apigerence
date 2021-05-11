using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("bimestre")]
    public class Bimestre
    {
        public long id { get; set; }
        public string bimestre { get; set; }
    }
}
