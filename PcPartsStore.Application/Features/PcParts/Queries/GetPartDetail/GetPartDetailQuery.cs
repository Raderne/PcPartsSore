using MediatR;

namespace PcPartsStore.Application.Features.PcParts.Queries.GetPartDetail
{
    public class GetPartDetailQuery : IRequest<PartDetailVm>
    {
        public Guid Id { get; set; }
    }
}
