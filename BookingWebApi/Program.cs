using BookingWebApi.BookingWebApi.Core.Models;
using BookingWebApi.BookingWebApi.DataAccess.Repositories;
using BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces;
using BookingWebApi.BookingWebApi.Security.Hashers;
using BookingWebApi.BookingWebApi.Security.JWT;
using BookingWebApi.BookingWebApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookingWebApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<PropertyRepository>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<PropertyService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<UserService>();

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
