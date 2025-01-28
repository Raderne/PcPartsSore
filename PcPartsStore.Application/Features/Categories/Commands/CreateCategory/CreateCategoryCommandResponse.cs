using PcPartsStore.Application.Responses;

namespace PcPartsStore.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {
        }
        public CreateCategoryDto Category { get; set; } = default!;
    }
}
