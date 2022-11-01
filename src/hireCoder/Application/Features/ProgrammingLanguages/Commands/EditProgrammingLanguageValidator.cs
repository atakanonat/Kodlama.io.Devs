using Application.Features.ProgrammingLanguages.DTOs;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class EditProgrammingLanguageValidator : AbstractValidator<EditedProgrammingLanguageDTO>
    {
        public EditProgrammingLanguageValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}