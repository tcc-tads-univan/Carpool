using Carpool.Api;
using Carpool.Api.Extensions;
using Carpool.Api.Middleware;
using Carpool.BLL;
using Carpool.DAL;

var builder = WebApplication.CreateBuilder(args);
var ionicFrontend = "IonicFrontend";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: ionicFrontend,
        policyBuilder => policyBuilder
            .WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPresentationLayer();
builder.Services.AddBusinessLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddMassTransitDependency(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ionicFrontend);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();