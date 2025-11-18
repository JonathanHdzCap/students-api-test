using Microsoft.EntityFrameworkCore;
using Usuarios.Api.Data;
using Usuarios.Api.Repository.Interfaces;
using Usuarios.Api.Repository;
using Usuarios.Api.Services;
using Usuarios.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Repositorios
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

//Service
builder.Services.AddScoped<IStudentService, StudentService>();

//Habilitar CORS globalmente
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()   
            .AllowAnyMethod()  
            .AllowAnyHeader(); 
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API V1");
    c.RoutePrefix = "swagger"; // o "" para raíz
});

app.MapGet("/", () => "Api .Net Minimal API Students");
app.MapStudentsEndpoints();
app.MapEmailsEndpoints();
app.MapPhonesEndpoints();
app.MapAddressesEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.Run();
