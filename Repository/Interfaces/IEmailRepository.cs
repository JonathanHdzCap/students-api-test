using Usuarios.Api.Models;

namespace Usuarios.Api.Repository.Interfaces
{
    public interface IEmailRepository
    {
        Task<List<Email>> GetAll(int studentId);
        Task<Email?> Get(string email);
        Task<string> Create(Email email);
        Task<int> Update(string email, Email emailData);
        Task<int> Delete(string email);
    }
}
