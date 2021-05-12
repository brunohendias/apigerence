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
        public long cod_serie_v { get; set; }
        [Required]
        public long cod_atencao { get; set; }
        [Required]
        public long cod_insc { get; set; }

        [ForeignKey("cod_serie_v")]
        public SerieVinculo InfosSerie { get; set; }

        [ForeignKey("cod_atencao")]
        public Atencao Atencao { get; set; }

        [ForeignKey("cod_insc")]
        public Inscricao Inscricao { get; set; }
    }
}
