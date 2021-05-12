﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("turno")]
    public class Turno
    {
        [Key]
        public long cod_turno { get; set; }
        [Required]
        public string turno { get; set; }
    }
}
