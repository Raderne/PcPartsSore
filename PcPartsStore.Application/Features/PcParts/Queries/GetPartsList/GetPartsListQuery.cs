using MediatR;

namespace PcPartsStore.Application.Features.PcParts.Queries.GetPartsList
{
    public class GetPartsListQuery : IRequest<List<PartsListVm>>
    {
    }
}
