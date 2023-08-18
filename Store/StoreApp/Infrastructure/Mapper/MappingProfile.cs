using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        }
    }
}
