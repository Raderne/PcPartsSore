namespace PcPartsStore.Application.Features.PcParts.Queries.GetPartsList
{
    public class PartsListVm
    {
        public Guid PartId { get; set; }
        public string? PartName { get; set; }
        public decimal PartPrice { get; set; }
        public string? PartImage { get; set; }
        public string? PartQuantity { get; set; }
    }
}
