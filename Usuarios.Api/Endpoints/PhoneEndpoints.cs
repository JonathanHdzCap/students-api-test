using Microsoft.AspNetCore.Mvc;
using Usuarios.Api.Models;
using Usuarios.Api.Services;

namespace Usuarios.Api.Endpoints
{
    public static class PhonesEndpoints
    {
        public static void MapPhonesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/phones")
                .WithTags("Phones");

            group.MapGet("/{studentId}", async (IStudentService studentService, int studentId) => {
                var resul = await studentService.GetAllPhonesAsync(studentId);
                return Results.Ok(resul);
            });

            //Crear nuevo phone
            group.MapPost("/", async (IStudentService studentService, Phone phone) =>
            {
                var result = await studentService.AddPhoneAsync(phone);
                return Results.Created($"/students/{phone.StudentId}", phone);
            });

            //Actualizar phone
            group.MapPut("/", async (IStudentService studentService, Phone phone) =>
            {
                if (phone.PhoneId == 0 || phone.PhoneId == null)
                    return Results.BadRequest();

                var success = await studentService.UpdatePhoneAsync(phone.PhoneId, phone);
                return success > 0 ? Results.NoContent() : Results.NotFound();
            });

            //Baja logica del phone
            group.MapDelete("/", async (IStudentService studentService, [FromBody] Phone phone) =>
            {
                if (phone.PhoneId == 0 || phone.PhoneId == null)
                    return Results.BadRequest();

                var result = await studentService.DeletePhoneAsync(phone.PhoneId);
                return result <= 0 ? Results.NotFound() : Results.Ok(result);
            });
        }
    }
}
