namespace ToDoListAPI.DTOs{
public class TodoResponseDTO{
    public int Id{get; set;}
    public string Title{get; set;}
    public string Description{get; set;}
    public string IsCompleted{get; set;}
    public DateTime DueDate{get; set;}

}}