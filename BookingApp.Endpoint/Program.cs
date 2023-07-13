
using BookingApp.Logic.Classes;
using BookingApp.Models.Models;
using BookingApp.Repository.Database;
using BookingApp.Repository.Interfaces;
using BookingApp.Repository.ModelRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(connectionString).UseLazyLoadingProxies());

//Jelszó megkötés
builder.Services.AddIdentity<SiteUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 8;
    option.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<BookingDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddTransient<IRepository<Appointment>, AppointmentRepository>();
builder.Services.AddTransient<IRepository<Service>, ServiceRepository>();

builder.Services.AddTransient<IAppointmentLogic, AppointmentLogic>();
builder.Services.AddTransient<IServiceLogic, ServiceLogic>();

builder.Services.AddSignalR();

//Bejelentkezés authentikálása JWT
builder.Services.AddAuthentication
(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme
    ;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme
    ;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme
    ;
}).AddJwtBearer
(options =>
{
    options.SaveToken = true
    ;
    options.RequireHttpsMetadata = true
    ;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true
    ,
        ValidateAudience = true
    ,
        ValidAudience = "http://www.security.org",
        ValidIssuer = "http://www.security.org",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nagyonhosszutitkoskodhelye"))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
.AllowCredentials()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins("http://localhost:4200"));


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapHub<SignalRHub>("/hub");
//});

app.Run();
