using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Model;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/v1/EventEmployee")]
    [ApiController]
    public class EventEmployeeController : ControllerBase
    {
        /// <summary>
        /// Обработка запроса на получение данных о событиях сотрудника из базы данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<EventEmployee>>> GetEventEmployee(int id)
        {
            using (var db = new MyDbContext())
            {                
                    var events = await db.EventEmployees.Include(e => e.EventEmployeeType).Where(e => e.EmployeeId == id).ToListAsync();
                    if (events == null)
                    {
                        return NotFound("Событие сотрудника не найдены");
                    }
                    return Ok(events.ConvertAll(p => new EventEmployeeModel(p)));
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostEventEmployee(EventEmployeeRequest employee)
        {
            using (var db = new MyDbContext())
            {
                if (employee != null)
                {
                    var events = new EventEmployee()
                    {
                        Id = employee.Id,
                        EmployeeId = employee.EmployeeId,
                        DateStart = employee.DateStart,
                        DateEnd = employee.DateEnd,
                        EventEmployeeTypeId = employee.EventEmployeeTypeId,
                    };
                    await db.AddAsync(events);
                    await db.SaveChangesAsync();
                    return StatusCode(201, "Событие добавлено");
                }
                return BadRequest();
                
            }
        }
    }
}
