using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("candidato")]
    public class Candidato
    {

        [Key]
        public long cod_can { get; set; }
        [Required]
        [MaxLength(50)]
        public string nome { get; set; }
        [Required]
        [ForeignKey("SerieVinculo")]
        public long cod_serie_v { get; set; }
        [Required]
        [ForeignKey("Atencao")]
        public long cod_atencao { get; set; }
        [Required]
        [ForeignKey("Inscricao")]
        public long cod_insc { get; set; }

        public virtual SerieVinculo SerieVinculo { get; set; }
        public virtual Atencao Atencao { get; set; }
        public virtual Inscricao Inscricao { get; set; }
    }
}
