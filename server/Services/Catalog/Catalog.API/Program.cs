var builder = WebApplication.CreateBuilder(args);

//ADD Services to the container

var app = builder.Build();

// config the http request pipeline

app.Run();
