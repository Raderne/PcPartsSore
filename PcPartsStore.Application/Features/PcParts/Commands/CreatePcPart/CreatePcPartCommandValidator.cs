using FluentValidation;
using PcPartsStore.Application.Contracts.Persistence;

namespace PcPartsStore.Application.Features.PcParts.Commands.CreatePcPart
{
    public class CreatePcPartCommandValidator : AbstractValidator<CreatePcPartCommand>
    {
        private readonly IPartsReposotory _partsReposotory;
        public CreatePcPartCommandValidator(IPartsReposotory partsReposotory)
        {
            _partsReposotory = partsReposotory;

            RuleFor(p => p.PartName)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(PcPartNameUnique)
                .WithMessage("An Pc Part with the same name and date already exists.");
        }

        private async Task<bool> PcPartNameUnique(CreatePcPartCommand command, CancellationToken token)
        {
            return !await _partsReposotory.IsPartsNameUnique(command.PartName);
        }
    }
}
