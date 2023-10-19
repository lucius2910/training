using Services.Utils;
using FluentValidation;

namespace Services.Request
{
    public class TodoRequest
    {
        public string head { get; set; }

        public string des { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    public class TodoRequestValidator : AbstractValidator<TodoRequest>
    {
        public TodoRequestValidator()
        {
            RuleFor(x => x.head).NotNull().WithMessage("456456").NotEmpty().WithMessage("123123");
            RuleFor(x => x.des).NotNull().MaximumLength(100);
        }
    }
}
