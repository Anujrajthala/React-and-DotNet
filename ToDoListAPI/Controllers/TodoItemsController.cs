// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SQLitePCL;
// using ToDoListAPI.Data;
// using ToDoListAPI.Models;

// namespace ToDoListAPI.Controllers{
//     [Route("api/[controller]")]
//     [ApiController]
//     public class TodoItemsController: ControllerBase{
//         private readonly TodoContext _context;
//         public TodoItemsController(TodoContext context){
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Todo>>> GetTodoList(){
//             return await _context.Todos.ToListAsync();
//         }

//         [HttpPost]
//         public async Task<ActionResult<Todo>> AddTodos(Todo TodoItem){
//             _context.Todos.Add(TodoItem);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetTodoList), new{TodoItem.Id},TodoItem);
            
//         }

//         [HttpPut("{id}")]

//         public async Task<ActionResult> UpdateTodo( int id, Todo TodoItem){
//             if(id != TodoItem.Id){
//                 return BadRequest();
//             }
//             _context.Entry(TodoItem).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult> DeleteTodo(int id){
//             var TodoItem = await _context.Todos.FindAsync(id);
//             if(TodoItem== null){
//                 return NotFound();
//             }
//             _context.Todos.Remove(TodoItem);
//             await _context.SaveChangesAsync();
//             return NoContent();

//         }

//     }
// }