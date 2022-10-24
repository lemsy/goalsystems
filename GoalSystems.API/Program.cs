using GoalSystems.API;
using GoalSystems.Domain.Business;
using GoalSystems.Infrastructure.Data;
using GoalSystems.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;


var devAllowSpecificOrigins = "_devAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: devAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44492")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryContext>(o => o.UseInMemoryDatabase("InventoryDb"));
//builder.Services.AddScoped<InventoryContext>();

builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    AppCustomConfig.InitializeInMemoryDatabase(app);
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(devAllowSpecificOrigins);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
