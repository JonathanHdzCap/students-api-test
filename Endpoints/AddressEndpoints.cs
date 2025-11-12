using Microsoft.AspNetCore.Mvc;
using Usuarios.Api.Models;
using Usuarios.Api.Services;

namespace Usuarios.Api.Endpoints
{
    public static class AddressEndpoints
    {
        public static void MapAddressesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/addresses")
                .WithTags("Addresses");

            group.MapGet("/{studentId}", async (IStudentService studentService, int studentId) => {
                var resul = await studentService.GetAllAddressesAsync(studentId);
                return Results.Ok(resul);
            });

            //Crear nuevo address
            group.MapPost("/", async (IStudentService studentService, Address address) =>
            {
                var result = await studentService.AddAddressAsync(address);
                return Results.Created($"/students/{address.StudentId}", address);
            });

            //Actualizar address
            group.MapPut("/", async (IStudentService studentService, Address address) =>
            {
                if (address.AddressId == 0)
                    return Results.BadRequest();

                var success = await studentService.UpdateAddressAsync(address.AddressId, address);
                return success > 0 ? Results.NoContent() : Results.NotFound();
            });

            //Baja logica del address
            group.MapDelete("/", async (IStudentService studentService, [FromBody] Address address) =>
            {
                if (address.AddressId == 0)
                    return Results.BadRequest();

                var result = await studentService.DeleteAddressAsync(address.AddressId);
                return result <= 0 ? Results.NotFound() : Results.Ok(result);
            });
        }
    }
}
