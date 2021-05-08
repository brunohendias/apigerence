using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("serie_v")]
    public class SerieVinculo
    {
        [Column("cod_serie_v")]
        public long id { get; set; }
        public int qtd_alunos { get; set; }
        public int limite_alunos { get; set; }
        public long cod_serie { get; set; }
        public long cod_turno { get; set; }
        public long cod_turma { get; set; }
        public long cod_prof { get; set; }

    }
}
