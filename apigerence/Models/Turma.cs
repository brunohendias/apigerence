using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("turma")]
    public class Turma
    {
        [Key]
        public long cod_turma { get; set; }
        public string turma { get; set; }
    }
}
