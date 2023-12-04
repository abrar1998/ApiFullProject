using API_FULL_PROJECT.DataContext;
using API_FULL_PROJECT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_FULL_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext context;

        public StudentsController(StudentContext context)
        {
            this.context = context;
        }

        //Get all
        //:- Get  ap/Students
        [HttpGet]
        public async Task<IActionResult> Getstudents()
        {
            var data = await context.students.ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //Get by Id
        //Get:- api/Students/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            if(context.students==null)
            {
                return NotFound();
            }
            var data = await context.students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //Put : api/Students/{id}
        //Put Method :- Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student stud)
        {
            if(id!=stud.Id)
            {
                return BadRequest();
            }
            context.Entry(stud).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException();
            }

            return Ok();
        }

        //Post: api/Students
        [HttpPost]
        public async Task<IActionResult> PostStudents(Student std)
        {
            if(context.students==null)
            {
                return Problem("Students Database is Null");
            }
            await context.students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Delete: api/Students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if(context.students==null)
            {
                return NotFound();
            }
            var data = await context.students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            context.students.Remove(data);
            await context.SaveChangesAsync();   
            return Ok();
        }

    }
}
