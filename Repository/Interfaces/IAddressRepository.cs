using Usuarios.Api.Models;

namespace Usuarios.Api.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAll(int studentId);
        Task<Address?> GetById(int addressId);
        Task<int> Create(Address address);
        Task<int> Update(int addressId, Address address);
        Task<int> Delete(int addressId);
    }
}
