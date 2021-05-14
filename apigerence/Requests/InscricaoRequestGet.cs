namespace apigerence.Requests
{
    public class InscricaoRequestGet
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public long cod_serie { get; set; }
        public long cod_atencao { get; set; }
        public long cod_turno { get; set; }
    }
}
