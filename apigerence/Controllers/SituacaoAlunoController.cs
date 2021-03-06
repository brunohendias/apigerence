using apigerence.Models;
using apigerence.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SituacaoAlunoController
    {
        private readonly ISituacaoAluno _interface;

        public SituacaoAlunoController(ISituacaoAluno contract) => _interface = contract;

        [HttpGet]
        public object Get()
        {
            try { return _interface.Get(); }

            catch (Exception e) { return e; }
        }

        [HttpGet("{id}")]
        public object Find(long id)
        {
            try { return _interface.Find(id); }

            catch (Exception e) { return e; }
        }

        [HttpPost]
        public object Post([FromBody] SituacaoAluno request)
        {
            try { return _interface.Post(request); }

            catch (Exception e) { return e; }
        }

        [HttpPut]
        public object Put([FromBody] SituacaoAluno request)
        {
            try { return _interface.Put(request); }

            catch (Exception e) { return e; }
        }

        [HttpDelete("{id}")]
        public object Delete(long id)
        {
            try { return _interface.Delete(id); }

            catch (Exception e) { return e; }
        }
    }
}
