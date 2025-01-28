using PcPartsStore.Application.Responses;

namespace PcPartsStore.Application.Features.PcParts.Commands.CreatePcPart
{
    public class CreatePcPartCommandResponse : BaseResponse
    {
        public CreatePcPartCommandResponse() : base()
        {
        }

        public CreatePcPartDto Parts { get; set; } = default!;
    }
}
