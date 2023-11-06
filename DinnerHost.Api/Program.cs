using DinnerHost.Application;
using DinnerHost.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
}
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var key1 = builder.Configuration.GetValue<string>("super-secret-key");

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

