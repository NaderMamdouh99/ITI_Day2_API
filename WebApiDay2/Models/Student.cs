using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiDay2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public int? Age { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }
    }
}
