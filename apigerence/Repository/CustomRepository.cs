using apigerence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apigerence.Repository
{
    public interface ICustom
    {
        public long Custom(long num1, long num2);

        public string GeraRA(Aluno request);
    }

    public class CustomRepository : ICustom
    {
        public long Custom(long num1, long num2)
        {
            return num1 + num2;
        }

        public string GeraRA(Aluno request) => 
            "" + request.cod_can + request.cod_atencao + request.cod_situacao + request.cod_serie_v + request.cod_atencao;
    }
}
