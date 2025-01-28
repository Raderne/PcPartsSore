using AutoMapper;
using MediatR;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateCategoryCommandResponse = new UpdateCategoryCommandResponse();

            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateCategoryCommandResponse.Success = false;
                updateCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateCategoryCommandResponse.Success)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
                if (category == null)
                {
                    updateCategoryCommandResponse.Success = false;
                    updateCategoryCommandResponse.ValidationErrors = new List<string>() { "Category not found" };
                    return updateCategoryCommandResponse;
                }

                _mapper.Map(request, category, typeof(UpdateCategoryCommand), typeof(Category));

                await _categoryRepository.UpdateAsync(category);
            }

            return updateCategoryCommandResponse;
        }
    }
}
