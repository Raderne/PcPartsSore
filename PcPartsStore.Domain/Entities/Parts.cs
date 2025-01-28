using PcPartsStore.Domain.Common;

namespace PcPartsStore.Domain.Entities
{
    public class Parts : AuditableEntity
    {
        // Primary key (EF Core will recognize "Id" or "PartId" as the key by convention)
        public Guid PartId { get; set; }
        public string PartName { get; set; } = string.Empty;
        public decimal PartPrice { get; set; }
        public string PartImage { get; set; } = string.Empty;
        public string PartChipset { get; set; } = string.Empty;
        public string PartWarranty { get; set; } = string.Empty;
        public string? PartQuantity { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
