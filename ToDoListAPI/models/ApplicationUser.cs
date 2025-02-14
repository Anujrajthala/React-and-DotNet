using Microsoft.AspNetCore.Identity;

namespace ToDoListAPI.Models{
    public class ApplicationUser:IdentityUser{
        public string FullName{get; set;}
        public ICollection<TodoItem> TodoItems{get; set;}



        
    }
}