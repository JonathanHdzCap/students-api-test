using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Usuarios.Api.Data;
using Usuarios.Api.Models;
using Usuarios.Api.Repository.Interfaces;

namespace Usuarios.Api.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _appDbContext;

        public AddressRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public async Task<int> Create(Address address)
        {
           address.IsActive = true;
            _appDbContext.Add<Address>(address);
            if (await _appDbContext.SaveChangesAsync() > 0)
            {
                return address.AddressId;
            }
            else return 0;
        }

        public async Task<int> Delete(int addressId)
        {
            Address? addressToUpdate = await _appDbContext.Addresses.FindAsync(addressId);
            if (addressToUpdate == null)  return 0;
            
            addressToUpdate.IsActive = false;
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAll(int studentId)
        {
            return await _appDbContext.Addresses.
                AsNoTracking().Where(a => a.StudentId == studentId && a.IsActive).ToListAsync();
        }

        public async Task<Address?> GetById(int addressId)
        {
            return await _appDbContext.Addresses.FindAsync(addressId);
        }

        public async Task<int> Update(int addressId, Address address)
        {
            Address? addressToUpdate = await _appDbContext.Addresses.FindAsync(addressId);
            if (addressToUpdate == null) return 0;

            addressToUpdate.AddressLine = address.AddressLine;
            addressToUpdate.City = address.City;
            addressToUpdate.ZipPostcode = address.ZipPostcode;
            addressToUpdate.State = address.State;
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
