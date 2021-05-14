using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apigerence.Models
{
    [Table("atencao")]
    public class Atencao
    {
        [Key]
        [ForeignKey("Inscricao")]
        public long cod_atencao { get; set; }
        [Required]
        [MaxLength(50)]
        public string atencao { get; set; }

        [JsonIgnore]
        public List<Inscricao> Inscricoes { get; set; }
    }
}
