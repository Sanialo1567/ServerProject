using WebApplication1.ViewModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace WebApplication1.Mappers
{
    public class CathegoryMapper : BaseMapper<CathegoryViewModel, CathegoryDtoModel>
    {
        protected override Mapper VMModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CathegoryViewModel, CathegoryDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description)));

            return new Mapper(config);
        }

        protected override Mapper DtoModelToVMModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CathegoryDtoModel, CathegoryViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description)));

            return new Mapper(config);
        }
    }
}
