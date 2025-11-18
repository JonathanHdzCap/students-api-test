using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Usuarios.Api.Data;
using Usuarios.Api.Models;
using Usuarios.Api.Repository.Interfaces;

namespace Usuarios.Api.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmailRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<string> Create(Email email)
        {
            email.IsActive = true;
            email.CreatedOn = DateTime.Now;
            _appDbContext.Add<Email>(email);
            if (await _appDbContext.SaveChangesAsync() > 0)
            {
                return email.EmailAddress;
            }
            else return "";
        }

        public async Task<int> Delete(string email)
        {
            Email? emailToUpdate = await _appDbContext.Emails.FindAsync(email);
            if (emailToUpdate == null) return 0;

            emailToUpdate.IsActive = false;
            emailToUpdate.UpdatedOn = DateTime.Now;
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<Email?> Get(string email)
        {
            return await _appDbContext.Emails.FindAsync(email);
        }

        public async Task<List<Email>> GetAll(int studentId)
        {
            return await _appDbContext.Emails.
               AsNoTracking().Where(a => a.StudentId == studentId && a.IsActive).ToListAsync();
        }

        public async Task<int> Update(string email, Email emailData)
        {
            Email? emailToUpdate = await _appDbContext.Emails.FindAsync(email);
            if (emailToUpdate == null) return 0;

            emailToUpdate.EmailType = emailData.EmailType;
            emailToUpdate.UpdatedOn = DateTime.Now;
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
