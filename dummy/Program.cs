using dummy.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<pgdbContext>(options=>
options.UseNpgsql(builder.Configuration.GetConnectionString("demodbconnection"))
);
//builder.Services.AddDbContext<pgdbContext>(
  //  options =>
   //options.UseNpgsql(builder.Configuration.GetConnectionString("demodbconnection")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
