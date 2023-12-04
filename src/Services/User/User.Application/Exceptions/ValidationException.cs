using FluentValidation.Results;

namespace User.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Validation failure occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                .ToDictionary(x => x.Key, x => x.ToArray());
    }

    public readonly Dictionary<string, string[]> Errors;
}