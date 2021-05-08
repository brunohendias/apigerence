using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Column("cod_insc")]
        public long id { get; set; }
        public string nom_insc { get; set; }
        public DateTime data_nasci { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public char cpf { get; set; }
        public string rg { get; set; }
        public string nom_mae { get; set; }
        public string nom_pai { get; set; }
        public long cod_serie { get; set; }
        public long cod_atencao { get; set; }
        public long cod_turno { get; set; }
    }
}
