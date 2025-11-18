using Usuarios.Api.Models;
using Usuarios.Api.Services;

namespace Usuarios.Api.Endpoints.Handlers
{
    public static class StudentHandlers
    {
        public static async Task<IResult> GetAll(IStudentService service)
        {
            var list = await service.GetAllStudentsAsync();
            return Results.Ok(list);
        }

        public static async Task<IResult> GetById(IStudentService service, int id)
        {
            if (id <= 0)
                return Results.BadRequest();

            var student = await service.GetStudentAsync(id);
            return student is null ? Results.NotFound() : Results.Ok(student);
        }

        public static async Task<IResult> Create(IStudentService service, Student student)
        {
            var id = await service.AddNewStudentAsync(student);
            return Results.Created($"/students/{id}", student);
        }

        public static async Task<IResult> Update(IStudentService service, int id, Student student)
        {
            if (id <= 0)
                return Results.BadRequest();

            var result = await service.UpdateStudentAsync(id, student);
            return result > 0 ? Results.NoContent() : Results.NotFound();
        }

        public static async Task<IResult> Delete(IStudentService service, int id)
        {
            if (id <= 0)
                return Results.BadRequest();

            var result = await service.DeleteStudentAsync(id);
            return result <= 0 ? Results.NotFound() : Results.Ok(result);
        }
    }
}
