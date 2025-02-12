using FluentValidation;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Validators{
    public class LoginValidator: AbstractValidator<LoginDTO>{
        public LoginValidator(){
            RuleFor(x=> x.Email)
            .NotEmpty().EmailAddress().WithMessage("Valid Email is required.");

            RuleFor(x=>x.Password)
            .NotEmpty().MinimumLength(6).WithMessage("Password must be of atleast 6 characters.");
        }
    }
}