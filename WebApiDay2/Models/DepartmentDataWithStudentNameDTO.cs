namespace WebApiDay2.Models
{
    public class DepartmentDataWithStudentNameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Employees { get; set; } = new List<Student>();

    }
}
