using ManhPT.EF_Core_Assignment_1.Model;
using ManhPT.EF_Core_Assignment_1.Repository;
using ManhPT.EF_Core_Assignment_1.Repository.DepartmentRepository;
using ManhPT.EF_Core_Assignment_1.Repository.ProjectEmployeeRepository;
using ManhPT.EF_Core_Assignment_1.Repository.ProjectRepository;
using ManhPT.EF_Core_Assignment_1.Repository.SalaryRepository;
using ManhPT.EF_Core_Assignment_1.Service.DepartmentService;
using ManhPT.EF_Core_Assignment_1.Service.EmployeeService;
using ManhPT.EF_Core_Assignment_1.Service.ProjectEmployeeService;
using ManhPT.EF_Core_Assignment_1.Service.ProjectService;
using ManhPT.EF_Core_Assignment_1.Service.SalaryService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Business");
builder.Services.AddDbContext<BusinessContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<ISalaryService, SalaryService>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();

builder.Services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();
builder.Services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
