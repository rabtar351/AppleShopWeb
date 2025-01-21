using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Server.Context;
using Web_Server.Employees;
using Web_Server.Models;

namespace Web_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Обработка запроса на полученние всех данных
        // Processing request to get all data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            try
            {
                using (var db = new Test11234Context())
                {
                    return await db.Employees.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // Обработка запроса добавления данных в базу данных
        // Processing a request to add data to the database
        [HttpPost]
        public async Task<ActionResult> PostEmployee(EmployeeRequst employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest("Incorrect data");

                using (var db = new Test11234Context())
                {
                    var employeeAdd = new Employee()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        AdditionalInfo = employee.AdditionalInfo,
                        Office = employee.Office,
                        MobilePhone = employee.MobilePhone,
                        Email = employee.Email,
                        PositionId = employee.PositionId,
                        DepartmentId = employee.DepartmentId,
                        BirthDate = employee.BirthDate,

                    };
                    await db.AddAsync(employeeAdd);
                    await db.SaveChangesAsync();
                    return Ok("Сотрудник добавлен");
                }
            }
            catch
            {
                return BadRequest();
            }


        }
        // Обработка запроса удаления данных из базы данных
        // Processing a request to delete data from a database
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                if (Id == 0 || Id < 0)
                    return BadRequest("Неправильный идентификатор");

                using (var db = new Test11234Context())
                {
                    var employeeDelete = await db.Employees.FindAsync(Id);

                    if (employeeDelete == null)
                        return NotFound();

                    db.Employees.Remove(employeeDelete);
                    await db.SaveChangesAsync();

                    return NoContent();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Обработка запроса на поиск по имени
        // Processing a search request by name
        [HttpGet("search/byname")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee(string firstname)
        {
            try
            {
                if (string.IsNullOrEmpty(firstname))
                    return BadRequest("Name parametr is required");

                using (var db = new Test11234Context())
                {
                    var gameShop = await db.Employees.Where(c => c.FirstName.Contains(firstname)).ToListAsync();
                    if (gameShop.Any())
                        return Ok(gameShop);
                    else

                        return NotFound($"Product with name: {firstname} not found!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internall server error");
            }
        }


    }
}
