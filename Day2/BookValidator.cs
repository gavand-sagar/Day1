using FluentValidation;

namespace Day2
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title)
                .NotEmpty().WithMessage("should not be empty")
                .MinimumLength(3).WithMessage("must have min lenght 3")
                .Must(title => !string.IsNullOrWhiteSpace(title)).WithMessage("Should not have whitespace")
                ;

            RuleFor(book => book.Author)
                .NotEmpty()
                .When(x => x.Title == "C# Advanced")
                .MustAsync(async (value, c) =>
                {
                    await Task.FromResult(value != "John Doe");
                    return true;
                }).WithMessage("Author cannot be John Doe if title is C# Advanced");


        }
    }
}
