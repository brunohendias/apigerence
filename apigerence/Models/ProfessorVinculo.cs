using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("professor_v")]
    public class ProfessorVinculo
    {
        [Key]
        public long cod_prof_v { get; set; }
        [Required]
        public long cod_prof { get; set; }
        [Required]
        public long cod_atencao { get; set; }

        [ForeignKey("cod_prof")]
        public Professor Professor { get; set; }

        [ForeignKey("cod_atencao")]
        public Atencao Atencao { get; set; }
    }
}
