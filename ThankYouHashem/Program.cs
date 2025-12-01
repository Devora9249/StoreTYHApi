using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ThankYouHashem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<StoreContext>(options =>

//options.UseSqlServer("Server=DESKTOP-1VUANBN;DataBase=TYH;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));


options.UseSqlServer("Server=Srv2\\pupils;DataBase=215967852TYH;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
