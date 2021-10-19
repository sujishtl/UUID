using FluentValidation;
using Uuid.Models;

namespace Uuid.Validators
{
    public class SequenceEntryValidator : AbstractValidator<string>
    {
        public SequenceEntryValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
        }
    }
}
