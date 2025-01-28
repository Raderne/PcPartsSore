namespace PcPartsStore.Application.Features.PcParts.Queries.GetPartDetail
{
    public class PartDetailVm
    {
        public Guid PartId { get; set; }
        public string? PartName { get; set; }
        public decimal PartPrice { get; set; }
        public string? PartImage { get; set; }
        public string? PartChipset { get; set; }
        public string? PartWarranty { get; set; }
        public string? PartQuantity { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
