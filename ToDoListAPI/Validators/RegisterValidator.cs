using FluentValidation;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Validators{
    public class RegisterValidator: AbstractValidator<RegisterDTO>{
        public RegisterValidator(){
            RuleFor(x=> x.FullName)
            .NotEmpty().WithMessage("FullName is required.");
            RuleFor(x=>x.Email)
            .NotEmpty().EmailAddress().WithMessage("Valid Email is required");
            RuleFor(x=>x.Password)
            .NotEmpty().MinimumLength(6).WithMessage("Password must be atleast 6 characters");

        }
    }
}