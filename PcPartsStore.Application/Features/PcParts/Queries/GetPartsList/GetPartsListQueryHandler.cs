using AutoMapper;
using MediatR;
using PcPartsStore.Application.Contracts.Persistence;

namespace PcPartsStore.Application.Features.PcParts.Queries.GetPartsList
{
    public class GetPartsListQueryHandler : IRequestHandler<GetPartsListQuery, List<PartsListVm>>
    {
        private readonly IPartsReposotory _partsReposotory;
        private readonly IMapper _mapper;

        public GetPartsListQueryHandler(IPartsReposotory partsReposotory, IMapper mapper)
        {
            _partsReposotory = partsReposotory;
            _mapper = mapper;
        }

        public async Task<List<PartsListVm>> Handle(GetPartsListQuery request, CancellationToken cancellationToken)
        {
            var allParts = (await _partsReposotory.ListAllAsync()).OrderBy(x => x.PartName).ToList();

            return _mapper.Map<List<PartsListVm>>(allParts);
        }
    }
}
