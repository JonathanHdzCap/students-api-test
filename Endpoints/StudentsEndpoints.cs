using Usuarios.Api.Endpoints.Handlers;

namespace Usuarios.Api.Endpoints
{
    public static class StudentsEndpoints
    {
        public static void MapStudentsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/students")
                .WithTags("Students");

            //Obtener todos los estudiantes
            group.MapGet("/", StudentHandlers.GetAll);

            //Obtener por Id
            group.MapGet("/{studentId}", StudentHandlers.GetById);

            //Crear nuevo estudiante
            group.MapPost("/", StudentHandlers.Create);

            //Actualizar estudiante
            group.MapPut("/{studentId}", StudentHandlers.Update);

            //Baja logica del estudiante
            group.MapDelete("/{studentId}", StudentHandlers.Delete);
        }
    }
}
