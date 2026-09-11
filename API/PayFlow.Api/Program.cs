using Microsoft.EntityFrameworkCore;
using PayFlow.CrossCutting.IoC;
using PayFlow.Repository.Data.DataConfiguration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<PayFlow.Api.Middlewares.GlobalExceptionHandlers>();
builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (dbContext.Database.CanConnect())
    {
        dbContext.Database.Migrate();
        Console.WriteLine("DataBase is online and accessible!");
    }
    else
    {
        Console.WriteLine("DataBase is offline or inaccessible!");
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "v1"); });
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();