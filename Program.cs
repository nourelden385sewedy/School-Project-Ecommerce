using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;
using School_ECommerce.Repos;
using School_ECommerce.Repos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MyAppDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection")));

// Repos
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));



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
