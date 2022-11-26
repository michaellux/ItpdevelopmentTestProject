using FluentValidation;

namespace ItpdevelopmentTestProject.Models
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(task => task.StartDate)
                .LessThan(task => task.CancelDate)
                .WithMessage("Start time cannot be greater than End time")
                .NotEmpty();
        }
    }
}
