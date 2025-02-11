using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/v1/Event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            using (var db = new MyDbContext())
            {
                var list = await db.Events.Include(k => k.Calendar).Include(k => k.Calendar.Employee).ToListAsync();
                var eventModelList = list.ConvertAll(p => new EventModel(p));
                return Ok(list.ConvertAll(p => new EventModel(p)));
            }
        }
    }
}
