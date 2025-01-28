namespace PcPartsStore.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryPartsDto
    {
        public Guid PartId { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
        public string PartImage { get; set; }
        public string PartChipset { get; set; }
        public string PartWarranty { get; set; }
        public string? PartQuantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
