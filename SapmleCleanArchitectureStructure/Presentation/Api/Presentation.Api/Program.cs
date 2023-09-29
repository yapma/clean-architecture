using Core.Application.Extentions;
using Infrastructure.Persistence.Extentions;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);


//
var app = builder.Build();
//

// request pipeline
app.MapControllers();

app.Run();
