

using EMPManagment.API;
using EMPManegment.Inretface.EmployeesInterface.AddEmployee;
using EMPManegment.Inretface.Interface.CSC;
using EMPManegment.Inretface.Interface.UsersLogin;
using EMPManegment.Inretface.Services.AddEmployeeServies;
using EMPManegment.Inretface.Services.CSC;
using EMPManegment.Inretface.Services.UserLoginServices;
using EMPManegment.Repository.AddEmpRepository;
using EMPManegment.Repository.CSCRepository;
using EMPManegment.Repository.UserLoginRepository;
using EMPManegment.Services.AddEmployee;
using EMPManegment.Services.CSC;
using EMPManegment.Services.UserLogin;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BonifatiusEmployeesContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("EMPDbconn")));


builder.Services.AddScoped<IAddEmpDetails, AddEmpRepo>();
builder.Services.AddScoped<ICSC, CSCRepo>();
builder.Services.AddScoped<IUserLogin, UserLoginRepo> ();

builder.Services.AddScoped<IAddEmpDetailsServices, EmpService>();
builder.Services.AddScoped<ICSCServices, CSCService>();
builder.Services.AddScoped<IUserLoginServices, UserLoginService>();



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
