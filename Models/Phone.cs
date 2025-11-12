using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Usuarios.Api.Models
{
    [Table("phone")]
    public class Phone
    {
        [Key]
        [Column("phone_id")]
        public int PhoneId { get; set; }       

        [Column("phone")]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("phone_type")]
        public PhoneType PhoneType { get; set; }

        [Column("country_code")]
        [MaxLength(5)]
        public string CountryCode { get; set; } = string.Empty;

        [Column("area_code")]
        [MaxLength(5)]
        public string AreaCode { get; set; } = string.Empty;

        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

        [Column("updated_on")]
        public DateTime? UpdatedOn { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; } = null!;
    }
}
