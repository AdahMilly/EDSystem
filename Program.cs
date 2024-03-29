using EDSystem.Data;
using EDSystem.Services.IService;
using EDSystem.Services;
using Microsoft.EntityFrameworkCore;
using EDSystem.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection"));
});
//register a service
builder.Services.AddScoped<ICourse, CourseService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IJwt, JwtService>();
builder.AddSwaggenGenExtension();
//use automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.AddAuth();

builder.AddAdminPolicy();
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
