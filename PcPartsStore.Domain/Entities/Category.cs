using PcPartsStore.Domain.Common;

namespace PcPartsStore.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<Parts>? Parts { get; set; }
    }
}
