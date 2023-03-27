using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelpDeskAssignment.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HelpDeskAssignmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HelpDeskAssignmentContext") ?? throw new InvalidOperationException("Connection string 'HelpDeskAssignmentContext' not found.")));

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        //options.JsonSerializerOptions.IgnoreNullValues = true;   //Depricated option, use below
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;        
    });
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
