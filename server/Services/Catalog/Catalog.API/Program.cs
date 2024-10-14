var builder = WebApplication.CreateBuilder(args);

//ADD Services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof (Program).Assembly);
});

var app = builder.Build();

// config the http request pipeline
app.MapCarter();
app.Run();
