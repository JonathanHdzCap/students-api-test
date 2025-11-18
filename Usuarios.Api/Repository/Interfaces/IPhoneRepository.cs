using Usuarios.Api.Models;

namespace Usuarios.Api.Repository.Interfaces
{
    public interface IPhoneRepository
    {
        Task<List<Phone>> GetAll(int studentId);
        Task<Phone?> GetById(int phoneId);
        Task<int> Create(Phone phone);
        Task<int> Update(int phoneId, Phone phone);
        Task<int> Delete(int phoneId);
    }
}
