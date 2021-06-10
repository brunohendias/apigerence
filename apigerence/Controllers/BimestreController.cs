using apigerence.Models;
using apigerence.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace apigerence.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class BimestreController
    {
        private readonly MySqlContext _context;
        private readonly Queue _queue;

        public BimestreController(MySqlContext context, IConfiguration config)
        {
            _context = context;
            _queue = new Queue(config, "bimestre");
        }

        [HttpGet]
        public object Get()
        {
            try { return _context.Bimestres.ToList(); }
            
            catch (Exception e) { return e; }
        }

        [HttpPost]
        public async Task<object> Post(Bimestre request)
        {
            try
            {
                await _queue.Send(request);

                return request;
            }
            catch (Exception e) { return e; }
        }
    }
}
