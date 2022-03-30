using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AspDotNetCoreWebApi.DB;
using AspDotNetCoreWebApi.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TrainingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDB")));
builder.Services.AddScoped<IStudentDAL, StudentDAL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
