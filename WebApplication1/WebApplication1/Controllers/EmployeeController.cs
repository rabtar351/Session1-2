using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/v1/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Обработка запроса на получение данных из базы данных
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var list = await db.Employees.Include(k => k.Department).Include(k => k.Position).ToListAsync();
                    return Ok(list.ConvertAll(p => new EmployeeModel(p)));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Обработка запроса на отправление данных из базы данных
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>404("Не найдено")
        /// </returns>201("Сотрудник добавлен")
        [HttpPost]
        public async Task<ActionResult> PostEmployee(EmployeeRequest employee)
        {
            try
            {
                if (employee == null)
                    return StatusCode(404, "Не найдено");

                using (var db = new MyDbContext())
                {
                    var employeeAdd = new Employee()
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Patronymic = employee.Patronymic,
                        MobilePhone = employee.MobilePhone,
                        DepartmentId = employee.DepartmentId,
                        PositionId = employee.PositionId,
                        SupervisorId = employee.SupervisorId,
                        AssistentId = employee.AssistentId,
                        WorkPhone = employee.WorkPhone,
                        Email = employee.Email,
                        Office = employee.Office,
                        AdditionalInfo = employee.AdditionalInfo,
                    };

                    await db.AddAsync(employeeAdd);
                    await db.SaveChangesAsync();
                    return StatusCode(201, "Сотрудник добавлен");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> PatchEmployee(EmployeeRequest request)
        {
            using (var db = new MyDbContext())
            {
                if (request == null)
                {
                    return BadRequest("Переданы неверные данные");
                }

                var existingUser = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId);
                if (existingUser == null)
                {
                    return NotFound("Сотрудник не найдено");
                }

                existingUser.FirstName = request.FirstName;
                existingUser.LastName = request.LastName;
                existingUser.Email = request.Email;
                existingUser.Office = request.Office;
                existingUser.PositionId = request.PositionId;
                existingUser.DepartmentId = request.DepartmentId;
                existingUser.SupervisorId = request.SupervisorId;
                existingUser.AssistentId = request.AssistentId;
                existingUser.BirthDate = request.BirthDate;
                existingUser.WorkPhone = request.WorkPhone;
                existingUser.AdditionalInfo = request.AdditionalInfo;
                existingUser.MobilePhone = request.MobilePhone;
                await db.SaveChangesAsync();
                return Ok("Данные сотрудника изменены!");

            }
        }
    }
}
