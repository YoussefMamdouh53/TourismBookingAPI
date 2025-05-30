using Microsoft.EntityFrameworkCore;
using TourismBooking.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TourismBookingDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("RDS");
    options.UseNpgsql(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEndApp",
        policy =>
        {
            policy.WithOrigins(builder.Configuration.GetValue<string>("FrontendAppUrl") ?? "http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseRouting();
//app.UseCors("AllowFrontEndApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
