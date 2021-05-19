using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apigerence.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<EnderecoInsc> EnderecoInscs { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Atencao> Atencoes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Bimestre> Bimestres { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<SerieDisciplina> SerieDisciplinas { get; set; }
        public DbSet<SerieVinculo> SerieVinculos { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<SituacaoAluno> SituacaoAlunos { get; set; }
        public DbSet<Gambi> Gambis { get; set; }
        public DbSet<Gambi2> Gambi2s { get; set; }
    }

    [Table("gambiarra")]
    public class Gambi
    {
        [Key]
        public long codinsc { get; set; }
        public long codconc { get; set; }
        public string teste { get; set; }

    }

    [Table("gambiarra2")]
    public class Gambi2
    {
        [Key]
        public long id { get; set; }
        public long codinsc { get; set; }
        public long codconc { get; set; }
        public string teste { get; set; }

    }
}
