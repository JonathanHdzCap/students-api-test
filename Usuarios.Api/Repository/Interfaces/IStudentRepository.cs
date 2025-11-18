using Usuarios.Api.Models;

namespace Usuarios.Api.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetById(int studentId);
        Task<int> CreateStudentComplete(Student student);
        Task<int> Update(int studentId, Student student);
        Task<int> DeleteStudentComplete(int studentId);
    }
}
