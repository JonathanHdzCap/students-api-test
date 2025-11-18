using Microsoft.AspNetCore.Mvc;
using Usuarios.Api.Models;
using Usuarios.Api.Services;

namespace Usuarios.Api.Endpoints
{
    public static class EmailsEndpoints
    {
        public static void MapEmailsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/emails")
                .WithTags("Emails");

            group.MapGet("/{studentId}", async (IStudentService studentService, int studentId) => {
                var resul = await studentService.GetAllEmailsAsync(studentId);
                return Results.Ok(resul);
            });

            //Crear nuevo email
            group.MapPost("/", async (IStudentService studentService, Email email) =>
            {
                var result = await studentService.AddEmailAsync(email);
                return Results.Created($"/students/{email.StudentId}", email);
            });

            //Actualizar email
            group.MapPut("/", async (IStudentService studentService, Email email) =>
            {
                if (string.IsNullOrWhiteSpace(email.EmailAddress))
                    return Results.BadRequest();

                var success = await studentService.UpdateEmailAsync(email.EmailAddress, email);
                return success > 0 ? Results.NoContent() : Results.NotFound();
            });

            //Baja logica del email
            group.MapDelete("/", async (IStudentService studentService, [FromBody] Email email) =>
            {
                if (string.IsNullOrWhiteSpace(email.EmailAddress))
                    return Results.BadRequest();

                var result = await studentService.DeleteEmailAsync(email.EmailAddress);
                return result <= 0 ? Results.NotFound() : Results.Ok(result);
            });
        }
    }
}
