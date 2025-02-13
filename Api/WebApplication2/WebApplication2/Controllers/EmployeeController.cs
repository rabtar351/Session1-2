using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/v1/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Обработка запроса на получение данных о сотрудниках из базы данных
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


        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeRequest employee)
        {
            try
            {
                if (employee == null)

                    return StatusCode(404, "Не найдено");


                using (var db = new MyDbContext())
                {
                    var employeeAdd = new Employee
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Patronymic = employee.Patronymic,
                        MobilePhone = employee.MobilePhone,
                        BirthDate = employee.BirthDate,
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
                return StatusCode(400, "Некоректные данные {0}" + ex.Message);
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

                var existingEmployee = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId);
                if (existingEmployee == null)
                {
                    return NotFound("Сотрудник не найден");
                }

                existingEmployee.FirstName = request.FirstName;
                existingEmployee.LastName = request.LastName;
                existingEmployee.Email = request.Email;
                existingEmployee.Office = request.Office;
                existingEmployee.PositionId = request.PositionId;
                existingEmployee.DepartmentId = request.DepartmentId;
                existingEmployee.SupervisorId = request.SupervisorId;
                existingEmployee.AssistentId = request.AssistentId;
                existingEmployee.BirthDate = request.BirthDate;
                existingEmployee.WorkPhone = request.WorkPhone;
                existingEmployee.AdditionalInfo = request.AdditionalInfo;
                existingEmployee.MobilePhone = request.MobilePhone;
                await db.SaveChangesAsync();
                return Ok("Данные сотрудника изменены!");
            }
        }
    }
}
