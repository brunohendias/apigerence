using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("disciplina")]
    public class Disciplina
    {
        [Key]
        public long cod_disciplina { get; set; }
        [Required]
        public string disciplina { get; set; }
    }
}
