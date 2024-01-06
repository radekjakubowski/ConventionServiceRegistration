using ConventionServiceRegistration.Extensions;
using ConventionServiceRegistration.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServicesWithAttributes();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (IServiceOne serviceOne, IServiceTwo serviceTwo) =>
{
    var serviceOneMessage = serviceOne.GetMessage();
    var serviceTwoMessage = serviceTwo.GetMessage();

    var messages = new string[] { serviceOneMessage, serviceTwoMessage };

    return messages;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
