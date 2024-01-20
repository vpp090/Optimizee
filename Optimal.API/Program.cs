using Microsoft.VisualBasic;
using Optimal.API.Constants;
using Optimal.API.Controllers;
using Optimal.API.Extensions;
using Optimal.API.SignalR;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactCors", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader();
    });
});

builder.Services.AddSignalR();
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Optimal.API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("ReactCors");

app.MapHub<DataHub>(OptimalConstants.SignalRPattern);
app.MapControllers();

app.Run();
