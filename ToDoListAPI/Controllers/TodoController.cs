using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SQLitePCL;
using ToDoListAPI.Data;
using ToDoListAPI.Models;
using ToDoListAPI.Services;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController: ControllerBase{
        private readonly TodoService _todoService;
        public TodoController(TodoService todoService){
            _todoService = todoService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> CreateTodo(TodoCreateDTO dto){
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var todo  = _todoService.CreateTodoAsync(userId,dto);
            return Ok(todo);

        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetTodos(){
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var todos = await _todoService.GetTodoAsync(userId);
            if (todos == null ){return NotFound("No todos found for this user.");}
    
            return Ok(todos);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateTodo(int id , TodoUpdateDTO dto){
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var todo = await _todoService.UpdateTodoAsync(id, dto,userId);
            if(todo==null) return NotFound();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteTodo(int taskId){
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool result = await _todoService.DeleteTodoAsync(taskId, userId);
            if(!result){
                return NotFound(); 
            }
            return Ok(new{Message = "Todo was deleted successfully."});
        }
}}