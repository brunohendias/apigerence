namespace apigerence.Requests
{
    public class SerieVinculoRequestPost
    {
        public long cod_serie_v { get; set; }
        public int limite_alunos { get; set; }
        public long cod_serie { get; set; }
        public long cod_turno { get; set; }
        public long cod_turma { get; set; }
        public long cod_prof { get; set; }
    }
}
