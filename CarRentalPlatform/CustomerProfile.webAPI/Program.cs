using CustomerProfile.webAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CustomerProfileContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomersProfile")));

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
