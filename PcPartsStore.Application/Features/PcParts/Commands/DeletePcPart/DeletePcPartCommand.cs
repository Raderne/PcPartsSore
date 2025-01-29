using MediatR;

namespace PcPartsStore.Application.Features.PcParts.Commands.DeletePcPart
{
    public class DeletePcPartCommand : IRequest<DeletePcPartCommandResponse>
    {
        public Guid PartId { get; set; }
    }
}
