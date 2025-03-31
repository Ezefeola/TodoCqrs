using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Common.Filters;
using TodoCqrsApp.Data;

var builder = WebApplication.CreateBuilder(args);

string? DbConnection = builder.Configuration.GetConnectionString("DbConnection");
#region Services Area
builder.Services.AddControllers(options =>
{
    //options.Filters.Add<ResultFilterAttribute>();
    options.Filters.Add<ResultWithResultBaseSolution>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(DbConnection);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

#endregion Services Area

var app = builder.Build();

#region Middlewares Area
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
//app.UseResultMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion Middlewares Area

app.Run();