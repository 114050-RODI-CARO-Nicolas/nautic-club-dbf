using ClubNautico.Business.SociosBusiness.Commands;
using ClubNautico.Business.SociosBusiness.Queries;
using ClubNautico.Data;
using ClubNautico.Validations.DBValidation;
using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddScoped<ISocioValidations, SocioValidation>();
//builder.Services.AddScoped<IEmbarcacionValidation, EmbarcacionValidation>();

var app = builder.Build();

app.UseCors((config) => { 
  config.AllowAnyHeader();
config.AllowAnyMethod();
config.AllowAnyOrigin();
}
); ;

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
