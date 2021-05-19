using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GambiarraController : ResponseService
    {
        public GambiarraController(MySqlContext context) : base (context) { }

        [HttpGet]
        public object Get() => (
                    from gambi in _context.Gambis
                    join gambi2 in _context.Gambi2s
                        on new { gambi.codinsc, gambi.codconc }
                    equals new { gambi2.codinsc, gambi2.codconc }
                    select new { gambi, gambi2 }
                ).ToList();
    }
}
