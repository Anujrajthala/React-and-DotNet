using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace ToDoListAPI.Data{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        public DbSet<TodoItem> TodoItems{set; get;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<TodoItem>()
                .ToTable("TodoItems")
                .HasOne(t=> t.User)
                .WithMany(u=>u.TodoItems )
                .HasForeignKey(t=> t.UserId);
                
        }
    }
}