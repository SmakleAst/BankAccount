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

builder.Services.AddScoped<IBaseRepository<AccountEntity>, AccountRepository>();
builder.Services.AddScoped<IBaseRepository<ClientEntity>, ClientRepository>();
builder.Services.AddScoped<IBaseRepository<LegalClientEntity>, LegalClientRepository>();
builder.Services.AddScoped<IBaseRepository<IndividualClientEntity>, IndividualClientRepository>();
builder.Services.AddScoped<IBaseRepository<TransactionEntity>, TransactionRepository>();
builder.Services.AddScoped<IBaseRepository<InterestRateEntity>, InterestRateRepository>();
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
