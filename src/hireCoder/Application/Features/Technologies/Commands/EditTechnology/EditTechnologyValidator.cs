using Application.Features.Technologies.DTOs;
using FluentValidation;

namespace Application.Features.Technologies.Commands.EditTechnology
{
    public class EditTechnologyValidator : AbstractValidator<EditedTechnologyDTO>
    {
        public EditTechnologyValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}