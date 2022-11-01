using Application.Features.ProgrammingLanguages.DTOs;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class CreateProgrammingLanguageValidator : AbstractValidator<CreatedProgrammingLanguageDTO>
    {
        public CreateProgrammingLanguageValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}