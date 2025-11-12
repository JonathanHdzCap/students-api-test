using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Usuarios.Api.Data.DTO
{
    public class AddressDTO
    {
        public int? AddressId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressLine { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string ZipPostcode { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string State { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public int? StudentId { get; set; }
    }
}
