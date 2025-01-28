using AutoMapper;
using MediatR;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Features.PcParts.Commands.CreatePcPart
{
    public class CreatePcPartCommandhandler : IRequestHandler<CreatePcPartCommand, CreatePcPartCommandResponse>
    {
        private readonly IPartsReposotory _partsRepository;
        private readonly IMapper _mapper;

        public CreatePcPartCommandhandler(IPartsReposotory partsRepository, IMapper mapper)
        {
            _partsRepository = partsRepository;
            _mapper = mapper;
        }

        public async Task<CreatePcPartCommandResponse> Handle(CreatePcPartCommand request, CancellationToken cancellationToken)
        {
            var createPcPartCommandResponse = new CreatePcPartCommandResponse();

            var validator = new CreatePcPartCommandValidator(_partsRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPcPartCommandResponse.Success = false;
                createPcPartCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPcPartCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createPcPartCommandResponse.Success)
            {
                var pcPart = new Parts()
                {
                    PartName = request.PartName,
                    PartPrice = request.PartPrice,
                    PartImage = request.PartImage,
                    PartChipset = request.PartChipset,
                    PartWarranty = request.PartWarranty,
                    PartQuantity = request.PartQuantity,
                    CategoryId = request.CategoryId
                };
                pcPart = await _partsRepository.AddAsync(pcPart);
                createPcPartCommandResponse.Parts = _mapper.Map<CreatePcPartDto>(pcPart);
            }

            return createPcPartCommandResponse;
        }
    }
}
