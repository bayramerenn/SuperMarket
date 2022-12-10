using SuperMarket.Business;
using SuperMarket.Business.InitializerData;
using SuperMarket.Core.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<DbInitializer>();
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
}).ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConfigureServices(builder.Configuration);

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var initialiser = services.GetRequiredService<DbInitializer>();

    await initialiser.Ensure();
}

app.Run();