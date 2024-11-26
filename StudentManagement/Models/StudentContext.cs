using System.Data.Entity;

namespace StudentManagement.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=StudentContext")
        {
        }

        public DbSet<Student> Students { get; set;}
        public DbSet<Login> Login { get; set; }
    }
}
