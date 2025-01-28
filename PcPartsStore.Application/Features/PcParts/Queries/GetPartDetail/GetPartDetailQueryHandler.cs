using AutoMapper;
using MediatR;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Application.Exceptions;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Features.PcParts.Queries.GetPartDetail
{
    public class GetPartDetailQueryHandler : IRequestHandler<GetPartDetailQuery, PartDetailVm>
    {
        private readonly IPartsReposotory _partsReposotory;
        private readonly IAsyncReposotory<Category> _categoryReposotory;
        private readonly IMapper _mapper;

        public GetPartDetailQueryHandler(IPartsReposotory partsReposotory, IAsyncReposotory<Category> categoryReposotory, IMapper mapper)
        {
            _partsReposotory = partsReposotory;
            _categoryReposotory = categoryReposotory;
            _mapper = mapper;
        }

        public async Task<PartDetailVm> Handle(GetPartDetailQuery request, CancellationToken cancellationToken)
        {
            var part = await _partsReposotory.GetByIdAsync(request.Id);
            if (part == null)
            {
                throw new NotFoundException(nameof(Parts), request.Id);
            }
            var partDto = _mapper.Map<PartDetailVm>(part);

            var category = await _categoryReposotory.GetByIdAsync(part.CategoryId);
            partDto.Category = _mapper.Map<CategoryDto>(category);

            return partDto;
        }
    }
}
