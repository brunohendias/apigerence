﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models
{
    [Table("aluno_disciplina")]
    public class AlunoDisciplina
    {
        [Key]
        public long cod_aluno_disc { get; set; }
        [Required]
        public float nota { get; set; }
        [Required]
        public long cod_aluno { get; set; }
        [Required]
        public long cod_serie_disc { get; set; }
        [Required]
        public long cod_bimestre { get; set; }
        
        [ForeignKey("cod_aluno")] 
        public Aluno Alunos { get; set; }
        
        [ForeignKey("cod_serie_disc")] 
        public SerieDisciplina SerieDisciplinas { get; set; }
        
        [ForeignKey("cod_bimestre")]
        public Bimestre Bimestres { get; set; }
    }
}
