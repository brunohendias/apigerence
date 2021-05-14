namespace apigerence.Requests
{
    public class AlunoDisciplinaRequestPost
    {
        public long cod_aluno_disc { get; set; }
        public float nota { get; set; }
        public long cod_aluno { get; set; }
        public long cod_serie_disc { get; set; }
        public long cod_bimestre { get; set; }
    }
}
