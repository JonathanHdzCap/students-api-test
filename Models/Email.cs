using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Usuarios.Api.Models
{
    [Table("email")]
    public class Email
    {
        [Key]
        [Column("email")]
        [MaxLength(100)]
        public string EmailAddress { get; set; } = string.Empty;
       
        [Column("email_type")]
        public EmailType EmailType { get; set; }

        [Column("updated_on")]
        public DateTime? UpdatedOn { get; set; }

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; } = null!;
    }
}
