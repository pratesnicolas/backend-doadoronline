using FluentValidation.Results;

namespace DoadorOnline.Application;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = Array.Empty<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures.Select(x => x.ErrorMessage).ToArray();
    }

    public string[] Errors { get; }
}
