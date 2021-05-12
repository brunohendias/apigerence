using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("professor")]
    public class Professor
    {
        [Key]
        public long cod_prof { get; set; }
        [Required]
        public string nom_prof { get; set; }
    }
}
