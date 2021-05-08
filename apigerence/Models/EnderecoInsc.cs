using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("endereco_insc")]
    public class EnderecoInsc
    {
        [Column("cod_endereco_insc")]
        public long id { get; set; }
        public long cod_insc { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public int rua { get; set; }
        public string cep { get; set; }
    }
}
