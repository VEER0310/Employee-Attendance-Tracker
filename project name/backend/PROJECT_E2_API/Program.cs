using Microsoft.EntityFrameworkCore;
using PROJECT_E2_API.Data;
using PROJECT_E2_API.Repositories;
using PROJECT_E2_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

// add DbContext with ss connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  adding repos DI
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// adding services DI
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Navigate to /swagger to see your API docs
}

app.UseCors("AllowAngular");   
app.UseAuthorization();
app.MapControllers();

app.Run();



