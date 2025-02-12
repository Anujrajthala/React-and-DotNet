using Microsoft.AspNetCore.Identity;

namespace ToDoListAPI.Models{
    public class ApplicationUser:IdentityUser{
        public string FullName{set; get;}
        public ICollection<TodoItem> TodoItems{set; get;}



        
    }
}