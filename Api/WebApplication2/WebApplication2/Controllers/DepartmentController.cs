using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/v1/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            using (var db = new MyDbContext())
            {
                return await db.Departments.ToListAsync();
            }
        }
    }
}
