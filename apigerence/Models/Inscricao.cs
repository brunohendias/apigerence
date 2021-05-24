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
        [Required, MaxLength(90)]
        public string nome { get; set; }
        [Required]
        public DateTime data_nasci { get; set; }
        [MaxLength(90)]
        public string email { get; set; }
        [Required, MaxLength(14)]
        public string telefone { get; set; }
        [Required, MaxLength(11)]
        public string cpf { get; set; }
        [Required, MaxLength(9)]
        public string rg { get; set; }
        [Required, MaxLength(90)]
        public string nom_mae { get; set; }
        [Required, MaxLength(90)]
        public string nom_pai { get; set; }
        [Required, ForeignKey("Serie")]
        public long cod_serie { get; set; }
        [Required, ForeignKey("Atencao")]
        public long cod_atencao { get; set; }
        [Required, ForeignKey("Turno")]
        public long cod_turno { get; set; }

        public Serie Serie { get; set; }
        public Atencao Atencao { get; set; }
        public Turno Turno { get; set; }
    }
}
