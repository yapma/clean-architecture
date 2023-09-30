using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Core.Application.Extentions;
using Infrastructure.Persistence.Extentions;
using Microsoft.OpenApi.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddControllers(options =>
{
    options.AddDefaultResultConvention();
        //.AddResultConvention(resultStatusMap => resultStatusMap
        //.AddDefaultMap()
        //.For(ResultStatus.Ok, HttpStatusCode.OK)
        //.For(ResultStatus.NotFound, HttpStatusCode.NotFound));
});
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Sample Clean Architecture Structure - Yashar", 
        Version = "v1",
    });
});

//
var app = builder.Build();
//

// request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.DocumentTitle = "Sample Clean Architecture";
    });
}
app.MapControllers();

app.Run();
