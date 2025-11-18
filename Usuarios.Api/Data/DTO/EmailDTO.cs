using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Usuarios.Api.Models;

namespace Usuarios.Api.Data.DTO
{
    public class EmailDTO
    {

        [MaxLength(100)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public EmailType EmailType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? StudentId { get; set; }
    }
}
