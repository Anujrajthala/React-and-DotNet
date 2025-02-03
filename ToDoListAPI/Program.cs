using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;

var builder= WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContext>((options)=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

);
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll",policy=>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();