using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingVilla.Business.Account;
using ShoppingVilla.Data.Data;
using ShoppingVilla.Data.Entities.Interface;
using ShoppingVilla.Data.Entities.UnitOfWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AppSetting
string ConnStr =builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(ConnStr,b=>b.MigrationsAssembly("ShoppingVilla.Data")));
#endregion

#region DI

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

#endregion


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
