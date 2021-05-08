using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("candidato")]
    public class Candidato
    {
        [Column("cod_can")]
        public long id { get; set; }
        public string nom_can { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public long cod_serie_v { get; set; }
        public long cod_atencao { get; set; }
        public long cod_insc { get; set; }
    }
}
