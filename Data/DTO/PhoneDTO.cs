using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Usuarios.Api.Models;

namespace Usuarios.Api.Data.DTO
{
    public class PhoneDTO
    {
        public int? PhoneId { get; set; }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public PhoneType PhoneType { get; set; }

        [Required]
        [MaxLength(5)]
        public string CountryCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(5)]
        public string AreaCode { get; set; } = string.Empty;

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public int? StudentId { get; set; }
    }
}
