using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Usuarios.Api.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("last_name")]
        [MaxLength(45)]
        public string LastName { get; set; } = string.Empty;

        [Column("middle_name")]
        [MaxLength(45)]
        public string? MiddleName { get; set; }

        [Column("first_name")]
        [MaxLength(45)]
        public string FirstName { get; set; } = string.Empty;

        [Column("gender")]
        public Gender Gender { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

        [Column("updated_on")]
        public DateTime? UpdatedOn { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Email> Emails { get; set; } = new List<Email>();
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
    }
}
