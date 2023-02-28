using Microsoft.EntityFrameworkCore;
using TimeJournal;
using TimeJournal.API.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o => o.Filters.Add<GlobalExceptionFilter>());
builder.Services.AddTimeJournalDbContext(o => o.UseSqlServer(builder.Configuration.GetConnectionString("TimeJournal")));
builder.Services.AddTimeJournalServices();

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
