using Usuarios.Api.Models;
using Usuarios.Api.Services;

namespace Usuarios.Api.Endpoints
{
    public static class StudentsEndpoints
    {
        public static void MapStudentsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/students")
                .WithTags("Students");

            //Obtener todos los estudiantes
            group.MapGet("/", async (IStudentService studentService) =>
                Results.Ok(await studentService.GetAllStudentsAsync()));

            //Obtener por Id
            group.MapGet("/{studentId}", async (IStudentService studentService, int studentId) =>
            {
                if (studentId <= 0)
                    return Results.BadRequest();

                var student = await studentService.GetStudentAsync(studentId);
                return student is null ? Results.NotFound() : Results.Ok(student);
            });

            //Crear nuevo estudiante
            group.MapPost("/", async (IStudentService studentService, Student student) =>
            {
                var result = await studentService.AddNewStudentAsync(student);
                return Results.Created($"/students/{result}", student);
            });

            //Actualizar estudiante
            group.MapPut("/{studentId}", async (IStudentService studentService, int studentId, Student student) =>
            {
                if (studentId <= 0)
                    return Results.BadRequest();

                var success = await studentService.UpdateStudentAsync(studentId, student);
                return success > 0 ? Results.NoContent() : Results.NotFound();
            });

            //Baja logica del estudiante
            group.MapDelete("/{studentId}", async (IStudentService studentService, int studentId) =>
            {
                if (studentId <= 0)
                    return Results.BadRequest();

                var result = await studentService.DeleteStudentAsync(studentId);
                return result <= 0 ? Results.NotFound() : Results.Ok(result);
            });
        }
    }
}
