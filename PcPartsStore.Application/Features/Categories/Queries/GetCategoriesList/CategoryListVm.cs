namespace PcPartsStore.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<CategoryPartsDto> Parts { get; set; } = new List<CategoryPartsDto>();
    }
}
