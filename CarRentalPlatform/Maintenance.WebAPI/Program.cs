using AGMaintenance.WebAPI.Middleware;
using Maintenance.WebAPI.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<AGIRepairHistoryService, AGFakeRepairHistoryService>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AGMaintenance.WebAPI",
        Version = "v1"
    });

    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-Api-Key",
        Type = SecuritySchemeType.ApiKey,
        Description = "Enter API Key"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});
//builder.Services.AddSwaggerGen(c =>
//{
//    c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//    {
//        Description = "API Key needed to access the endpoints. Example: MY_SECRET_KEY_123",
//        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
//        Name = "X-Api-Key",
//        In = Microsoft.OpenApi.Models.ParameterLocation.Header
//    });

//    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
//    {
//        {
//            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//            {
//                Reference = new Microsoft.OpenApi.Models.OpenApiReference
//                {
//                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                    Id = "ApiKey"
//                }
//            },
//            new string[] { }
//        }
//    });
//});

//const string API_KEY = "5214eee0-0f8c-407b-9bc4-3b33db2030a2";


var usageCounts = new Dictionary<string, int>();
builder.Services.AddSingleton(usageCounts);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<AGGlobalExceptionMiddleware>();
app.UseMiddleware<AGApiKeyMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();