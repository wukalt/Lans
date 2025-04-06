using Microsoft.EntityFrameworkCore;
using Toplearn.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<ToplearnDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();
app.UseStaticFiles();
app.MapGet("/", () => "Hello World!");

app.Run();
