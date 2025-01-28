using MediatR;

namespace PcPartsStore.Application.Features.PcParts.Commands.CreatePcPart
{
    public class CreatePcPartCommand : IRequest<CreatePcPartCommandResponse>
    {
        public string PartName { get; set; } = string.Empty;
        public decimal PartPrice { get; set; }
        public string PartImage { get; set; } = string.Empty;
        public string PartChipset { get; set; } = string.Empty;
        public string PartWarranty { get; set; } = string.Empty;
        public string? PartQuantity { get; set; }
        public Guid CategoryId { get; set; }

    }
}
