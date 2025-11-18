using Microsoft.EntityFrameworkCore;
using Usuarios.Api.Data;
using Usuarios.Api.Models;
using Usuarios.Api.Repository.Interfaces;

namespace Usuarios.Api.Repository
{
    public class PhoneRepository:IPhoneRepository
    {
        private readonly AppDbContext _appDbContext;

        public PhoneRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<int> Create(Phone phone)
        {
            phone.IsActive = true;
            phone.CreatedOn = DateTime.Now;
            _appDbContext.Add<Phone>(phone);
            if (await _appDbContext.SaveChangesAsync() > 0)
            {
                return phone.PhoneId;
            }
            else return 0;
        }

        public async Task<int> Delete(int phoneId)
        {
            Phone? phoneToUpdate = await _appDbContext.Phones.FindAsync(phoneId);
            if (phoneToUpdate == null) return 0;

            phoneToUpdate.IsActive = false;
            phoneToUpdate.UpdatedOn = DateTime.Now;
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Phone>> GetAll(int studentId)
        {
            return await _appDbContext.Phones.
                AsNoTracking().Where(a => a.StudentId == studentId && a.IsActive).ToListAsync();
        }

        public async Task<Phone?> GetById(int phoneId)
        {
            return await _appDbContext.Phones.FindAsync(phoneId);
        }

        public async Task<int> Update(int phoneId, Phone phone)
        {
            Phone? phoneToUpdate = await _appDbContext.Phones.FindAsync(phoneId);
            if (phoneToUpdate == null) return 0;

            phoneToUpdate.PhoneNumber = phone.PhoneNumber;
            phoneToUpdate.PhoneType = phone.PhoneType;
            phoneToUpdate.CountryCode = phone.CountryCode;
            phoneToUpdate.AreaCode = phone.AreaCode;
            phoneToUpdate.UpdatedOn = DateTime.Now;
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
