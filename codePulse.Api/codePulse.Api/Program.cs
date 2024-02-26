using AutoMapper;
using BLL;
using BLL.implemantation;
using BLL.Interface;
using DAL;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("codePulseConnectionString"));
//});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("codePulseConnectionString"),
        b => b.MigrationsAssembly("DAL")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IcategoryDal, CategoryDal>();

builder.Services.AddScoped<iRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IRegisterDal, RegisterDal>();

builder.Services.AddScoped<ILoginrepository, LoginRepository>();
builder.Services.AddScoped<ILoginDal, LoginDal>();

builder.Services.AddScoped<IKlipRepository, KlipRepository>();
builder.Services.AddScoped<IKlipDal, KlipDal>();

var config = new MapperConfiguration(m =>  m.AddProfile(new mapper()));
IMapper map = config.CreateMapper();
builder.Services.AddSingleton(map);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
