using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Data;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services{
 public class TodoService{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TodoService(ApplicationDbContext context, IMapper mapper ){
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<TodoResponseDTO> CreateTodoAsync(string userId, TodoCreateDTO dto){
        var todo = _mapper.Map<TodoItem>(dto);
        todo.UserId = userId;
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return _mapper.Map<TodoResponseDTO>(todo);
    }

    public async Task<TodoResponseDTO> GetTodoAsync(string userId){
        var todos = await _context.TodoItems.Where(t=>t.UserId==userId).ToListAsync();
        return _mapper.Map<TodoResponseDTO>(todos);
    }
    public async Task<TodoResponseDTO> UpdateTodoAsync(int taskId, TodoUpdateDTO dto ,string UserId){
        var todo = await _context.TodoItems.FirstOrDefaultAsync(t=> t.Id== taskId);
        if(todo == null || todo.UserId != UserId){
            return null;
        }
        _mapper.Map(dto,todo);
        _context.SaveChangesAsync();
        return _mapper.Map<TodoResponseDTO>(todo);
    }

    public async Task<bool> DeleteTodoAsync(int Taskid, string userId){
        var todo = await _context.TodoItems.FirstOrDefaultAsync(t=> t.Id==Taskid);
        if(todo == null && todo.UserId!=userId) return false;
        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync();
        return true;


    }
 }
}