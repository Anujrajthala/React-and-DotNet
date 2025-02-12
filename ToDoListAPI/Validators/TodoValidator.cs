using FluentValidation;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Validators{
    public class TodoValidator: AbstractValidator<TodoCreateDTO>{
        public TodoValidator(){
            RuleFor(x=> x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title cannot be more than 100 characters");

            RuleFor(x=> x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot be more than 500 characters.");
        }
    }
}