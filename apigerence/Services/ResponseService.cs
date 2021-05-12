using apigerence.Models.Context;
using System;

namespace apigerence.Services
{
    public class Codes
    {
        public readonly int success = 200;
        public readonly int fail = 400;
        public readonly int error = 500;
    }

    public class Status
    {
        public readonly bool successed = true;
        public readonly bool failed = false;
        public readonly bool error = false;
    }

    public class Msg
    {
        public string success;
        public string fail;
        public string error = "Houve um erro durante o processamento.";
    }

    public class ResponseService
    {
        protected object Dados = null;
        protected MySqlContext _context;

        protected Msg msg;
        private readonly Codes _codes;
        private readonly Status _status;

        public ResponseService(MySqlContext context)
        {
            _codes = new Codes();
            _status = new Status();
            msg = new Msg();
            _context = context;
        }

        protected object MontaRetorno() =>
            Dados == null ? RespFail() : RespSuccess();

        private object RespSuccess() => new
        {
            code = _codes.success,
            status = _status.successed,
            msg = msg.success,
            dados = Dados
        };

        protected object RespFail() => new
        {
            code = _codes.fail,
            status = _status.failed,
            msg = msg.fail,
            dados = Dados
        };

        protected object RespErrorLog(Exception e) => new
        {
            code = _codes.error,
            status = _status.error,
            msg = msg.error,
            error = e.Message
        };
    }
}