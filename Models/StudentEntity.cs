using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }
}
