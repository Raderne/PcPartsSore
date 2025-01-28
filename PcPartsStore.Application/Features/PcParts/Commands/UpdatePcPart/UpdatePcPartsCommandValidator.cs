using FluentValidation;

namespace PcPartsStore.Application.Features.PcParts.Commands.UpdatePcPart
{
    public class UpdatePcPartsCommandValidator : AbstractValidator<UpdatePcPartsCommand>
    {
        public UpdatePcPartsCommandValidator()
        {
            RuleFor(p => p.PartName)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.PartChipset)
            .NotEmpty().WithMessage("{PropertyName} is Required.")
            .NotNull();

            RuleFor(p => p.PartQuantity)
            .NotEmpty().WithMessage("{PropertyName} is Required.")
            .NotNull();

            RuleFor(p => p.PartPrice)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .GreaterThan(10).WithMessage("{PropertyName} must exceed 10$.");
        }
    }
}
