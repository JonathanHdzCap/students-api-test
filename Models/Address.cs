using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Usuarios.Api.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [Column("address_id")]
        public int AddressId { get; set; }       

        [Column("address_line")]
        [MaxLength(100)]
        public string AddressLine { get; set; } = string.Empty;

        [Column("city")]
        [MaxLength(45)]
        public string City { get; set; } = string.Empty;

        [Column("zip_postcode")]
        [MaxLength(45)]
        public string ZipPostcode { get; set; } = string.Empty;

        [Column("state")]
        [MaxLength(45)]
        public string State { get; set; } = string.Empty;

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; } = null!;
    }
}
