using System;

namespace apigerence.Services
{
    public class Codes
    {
        public int success = 200;
        public int fail = 400;
        public int error = 500;
    }

    public class Status
    {
        public bool successed = true;
        public bool failed = false;
    }

    public class Msg
    {
        public string success { get; set; }
        public string fail { get; set; }
        public string error { get; set; } = "Houve um erro durante o processamento";
    }

    public class ResponseService
    {
        protected object Dados { get; set; } = null;

        protected Msg msg { get; set; }
        private readonly Codes _codes;
        private readonly Status _status;

        public ResponseService()
        {
            _codes = new Codes();
            _status = new Status();
            msg = new Msg();
        }

        protected bool Empty() => Dados == null;

        protected object MontaRetorno() =>
                Empty() ? RespFail() : RespSuccess();

        protected object RespSuccess() => new {
                code = _codes.success,
                status = _status.successed,
                msg = msg.success,
                dados = Dados
        };

        protected object RespFail() => new {
                code = _codes.fail,
                status = _status.failed,
                msg = msg.fail,
                dados = Dados
        };
        protected object RespErrorLog(Exception e) => new {
                code = _codes.error,
                status = _status.failed,
                msg = msg.error,
                error = e.Message
        };
    }
}
