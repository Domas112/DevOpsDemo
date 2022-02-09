using DevOpsDemo.DataContexts;
using DevOpsDemo.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.Write("The azuredb connection variable is: ");
Console.WriteLine(System.Environment.GetEnvironmentVariable("AzureDBConnection"));
// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>(opt => opt.UseSqlServer(
        System.Environment.GetEnvironmentVariable("AzureDBConnection")
    ));
builder.Services.AddScoped<ITodosRepo, TodosRepo>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
