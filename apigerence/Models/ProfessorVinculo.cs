using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("professor_v")]
    public class ProfessorVinculo
    {
        [Column("cod_prof_v")]
        public long id { get; set; }
        public long cod_prof { get; set; }
        public long cod_atencao { get; set; }
    }
}
