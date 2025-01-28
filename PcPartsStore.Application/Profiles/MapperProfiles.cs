using AutoMapper;
using PcPartsStore.Application.Features.Categories.Commands.CreateCategory;
using PcPartsStore.Application.Features.Categories.Commands.UpdateCategory;
using PcPartsStore.Application.Features.Categories.Queries.GetCategoriesList;
using PcPartsStore.Application.Features.PcParts.Commands.CreatePcPart;
using PcPartsStore.Application.Features.PcParts.Commands.UpdatePcPart;
using PcPartsStore.Application.Features.PcParts.Queries.GetPartDetail;
using PcPartsStore.Application.Features.PcParts.Queries.GetPartsList;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Application.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryPartsDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Parts, CategoryPartsDto>().ReverseMap();
            CreateMap<Parts, PartsListVm>().ReverseMap();
            CreateMap<Parts, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Parts, PartDetailVm>().ReverseMap();
            CreateMap<Parts, CreatePcPartCommand>().ReverseMap();
            CreateMap<Parts, CreatePcPartDto>().ReverseMap();
            CreateMap<Parts, UpdatePcPartsCommand>().ReverseMap();
        }
    }
}
