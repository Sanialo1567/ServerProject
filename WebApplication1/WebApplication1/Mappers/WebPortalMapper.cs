using AutoMapper;
using BusinessLogicLayer.DtoModels;
using WebApplication1.ViewModels;

namespace WebApplication1.Mappers
{
    public class WebPortalMapper : BaseMapper<WebPortalViewModel, WebPortalDtoModel>
    {
        protected override Mapper VMModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WebPortalViewModel, WebPortalDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                   .ForMember(x => x.OwnerId, y => y.MapFrom(x => x.OwnerId))
                   .ForMember(x => x.CathegoryId, y => y.MapFrom(x => x.CathegoryId)));

            return new Mapper(config);
        }

        protected override Mapper DtoModelToVMModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WebPortalDtoModel, WebPortalViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                   .ForMember(x => x.OwnerId, y => y.MapFrom(x => x.OwnerId))
                   .ForMember(x => x.CathegoryId, y => y.MapFrom(x => x.CathegoryId)));

            return new Mapper(config);
        }
    }
}
