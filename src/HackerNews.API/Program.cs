using HackerNews.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseInfrastructure();
app.Run();