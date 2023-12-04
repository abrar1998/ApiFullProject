using API_FULL_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace API_FULL_PROJECT.DataContext
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> opt):base(opt)
        {
            
        }

        public DbSet<Student> students { get; set; } = null!;
    }
}
