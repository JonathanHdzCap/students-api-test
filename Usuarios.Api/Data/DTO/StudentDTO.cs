using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Usuarios.Api.Models;

namespace Usuarios.Api.Data.DTO
{
    public class StudentDTO
    {
        public int? StudentId { get; set; }

        [Required]
        [MaxLength(45)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string MiddleName { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public List<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();
        public List<EmailDTO> Emails { get; set; } = new List<EmailDTO>();
        public List<PhoneDTO> Phones { get; set; } = new List<PhoneDTO>();
    }
}
