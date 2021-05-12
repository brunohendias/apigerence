using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Key]
        public long cod_insc { get; set; }
        [Required]
        public string nom_insc { get; set; }
        [Required]
        public DateTime data_nasci { get; set; }
        public string email { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string rg { get; set; }
        [Required]
        public string nom_mae { get; set; }
        [Required]
        public string nom_pai { get; set; }
        [Required]
        public long cod_serie { get; set; }
        [Required]
        public long cod_atencao { get; set; }
        [Required]
        public long cod_turno { get; set; }

        [ForeignKey("cod_serie")]
        public Serie Serie { get; set; }

        [ForeignKey("cod_atencao")]
        public Atencao Atencao { get; set; }

        [ForeignKey("cod_turno")]
        public Turno Turno { get; set; }
    }
}
