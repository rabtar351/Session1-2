using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/v1/Position")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPosition()
        {
            using (var db = new MyDbContext())
            {
                return await  db.Positions.ToListAsync();
            }
        }
    }
}
