using BankAccount.DAL;
using BankAccount.DAL.Interfaces;
using BankAccount.DAL.Repositories;
using BankAccount.Domain.Entity;
using BankAccount.Service.Implementations;
using BankAccount.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBaseRepository<CheckAccountEntity>, CheckAccountRepository>();
builder.Services.AddScoped<IBaseRepository<SaveAccountEntity>, SaveAccountRepository>();
builder.Services.AddScoped<IBaseRepository<LegalEntity>, LegalRepository>();
builder.Services.AddScoped<IBaseRepository<IndividualEntity>, IndividualRepository>();
builder.Services.AddScoped<IBankService, BankService>();

var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

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
