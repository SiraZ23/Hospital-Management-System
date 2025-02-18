using Hospital_Management_System.API.Data;
using Hospital_Management_System.API.Mappings;
using Hospital_Management_System.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db Context Injection
builder.Services.AddDbContext<HospitalManagementDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalManagement")));

//Repository Injection
builder.Services.AddScoped<IPatientRepository,SQLPatientRepositorycs>();
builder.Services.AddScoped<IDoctorRepository, SQLDoctorRepository>();

//AutoMapper Injection
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
