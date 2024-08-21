using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Model;


namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }


        public DbSet<Student> Students { get; set; }
    }
}
