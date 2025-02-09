

var builder = WebApplication.CreateBuilder(args);

//add services to the container

builder.Services.AddCarter();
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

var app = builder.Build();

//configure the http request pipeline

app.MapCarter();
app.Run();
