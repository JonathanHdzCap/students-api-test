using Usuarios.Api.Models;

namespace Usuarios.Api.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task<int> AddNewStudentAsync(Student student);
        Task<int> DeleteStudentAsync(int studentId);
        Task<int> UpdateStudentAsync(int studentId, Student student);

        #region Phones Data
        Task<List<Phone>> GetAllPhonesAsync(int studentId);
        Task<int?> AddPhoneAsync(Phone phone);
        Task<int> UpdatePhoneAsync(int phoneId, Phone phone);
        Task<int> DeletePhoneAsync(int phoneId);
        #endregion Phones Data

        #region Email Data
        Task<List<Email>> GetAllEmailsAsync(int studentId);
        Task<string?> AddEmailAsync(Email emailData);
        Task<int> UpdateEmailAsync(string email, Email emailData);
        Task<int> DeleteEmailAsync(string email);
        #endregion Eamil Data

        #region Address Data
        Task<List<Address>> GetAllAddressesAsync(int studentId);
        Task<int?> AddAddressAsync(Address address);
        Task<int> UpdateAddressAsync(int addressId, Address address);
        Task<int> DeleteAddressAsync(int addressId);
        #endregion Address Data

    }
}
