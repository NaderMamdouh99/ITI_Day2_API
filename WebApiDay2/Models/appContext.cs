using Microsoft.EntityFrameworkCore;

namespace WebApiDay2.Models
{
    public class appContext:DbContext
    {
        public appContext(){}
        public appContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Employees { get; set; }
    }
}
