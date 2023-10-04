using crud_api.persistence;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddSingleton<DevEventsDbContext>();
builder.Services.AddControllers();


app.MapGet("/", () => "Hello World!");

app.Run();
