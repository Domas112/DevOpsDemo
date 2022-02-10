using DevOpsDemo.DataContexts;
using DevOpsDemo.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? DBEnvVariable = System.Environment.GetEnvironmentVariable("AZURE_DB_CONNECTION");

Console.Write("The azuredb connection variable is: ");
Console.WriteLine(DBEnvVariable is null? "Empty" : DBEnvVariable);
// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>(opt => opt.UseSqlServer(DBEnvVariable));
builder.Services.AddScoped<ITodosRepo, TodosRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
           .WithMethods("GET", "PUT", "DELETE", "POST", "PATCH")); //not really necessary when AllowAnyMethods is used.
        
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
