using Microsoft.EntityFrameworkCore;
using Usuarios.Api.Data;
using Usuarios.Api.Models;
using Usuarios.Api.Repository.Interfaces;

namespace Usuarios.Api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<int> CreateStudentComplete(Student student)
        {
            student.IsActive = true;
            student.CreatedOn = DateTime.Now;
            _appDbContext.Add<Student>(student);
            if (await _appDbContext.SaveChangesAsync() > 0)
            {
                return student.StudentId;
            }
            else return 0;
        }

        public async Task<int> DeleteStudentComplete(int studentId)
        {
            var studentToUpdate = await _appDbContext.Students
                    .Include(s => s.Emails)
                    .Include(s => s.Addresses)
                    .Include(s => s.Phones)
                    .FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (studentToUpdate == null) return 0;

            var dateTime = DateTime.Now;

            studentToUpdate.IsActive = false;
            studentToUpdate.UpdatedOn = dateTime;

            foreach (var email in studentToUpdate.Emails)
            {
                email.UpdatedOn = dateTime;
                email.IsActive = false;
            }
            foreach (var address in studentToUpdate.Addresses)
            {
                address.IsActive = false;
            }
            foreach (var phone in studentToUpdate.Phones)
            {
                phone.IsActive = false;
                phone.UpdatedOn = dateTime;
            }

            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _appDbContext.Students.
               AsNoTracking().Where(a => a.IsActive).ToListAsync();
        }

        public async Task<Student?> GetById(int studentId)
        {
            return await _appDbContext.Students.FindAsync(studentId);
        }

        public async Task<int> Update(int studentId, Student student)
        {
            Student? studentToUpdate = await _appDbContext.Students.FindAsync(studentId);
            if (studentToUpdate == null) return 0;

            studentToUpdate.LastName = student.LastName;
            studentToUpdate.MiddleName = student.MiddleName;
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.Gender = student.Gender;
            studentToUpdate.UpdatedOn = DateTime.Now;
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
