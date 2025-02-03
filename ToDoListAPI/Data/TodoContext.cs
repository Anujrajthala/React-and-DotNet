using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data{
    public class TodoContext: DbContext{
        public TodoContext(DbContextOptions<TodoContext> options): base(options){}
        public DbSet<Todo> Todos{set; get;}
    }
}