using FluentValidation;
using Uuid.Models;

namespace Uuid.Validators
{
    public class SequenceEntryValidator : AbstractValidator<string>
    {
        public SequenceEntryValidator()
        {
            RuleFor(x => x).NotNull().NotEmpty();
            RuleFor(x => x).Matches(@"[0-9 ]+");
        }
    }
}
