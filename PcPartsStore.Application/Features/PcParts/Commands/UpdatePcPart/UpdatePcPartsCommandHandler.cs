using AutoMapper;
using MediatR;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Application.Exceptions;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Features.PcParts.Commands.UpdatePcPart
{
    public class UpdatePcPartsCommandHandler : IRequestHandler<UpdatePcPartsCommand>
    {
        private readonly IAsyncReposotory<Parts> _asyncReposotory;
        private readonly IMapper _mapper;

        public UpdatePcPartsCommandHandler(IAsyncReposotory<Parts> asyncReposotory, IMapper mapper)
        {
            _asyncReposotory = asyncReposotory;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePcPartsCommand request, CancellationToken cancellationToken)
        {
            var pcPartsToUpdate = await _asyncReposotory.GetByIdAsync(request.PartId);
            if (pcPartsToUpdate == null)
            {
                throw new NotFoundException(nameof(Parts), request.PartId);
            }

            var validator = new UpdatePcPartsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, pcPartsToUpdate, typeof(UpdatePcPartsCommand), typeof(Parts));

            await _asyncReposotory.UpdateAsync(pcPartsToUpdate);
        }
    }
}
