using WebApplication1.ViewModels;
using BusinessLogicLayer.DtoModels;
using AutoMapper;

namespace WebApplication1.Mappers
{
    public class NotificationMapper : BaseMapper<NotificationViewModel, NotificationDtoModel>
    {
        protected override Mapper VMModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NotificationViewModel, NotificationDtoModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.PostId, y => y.MapFrom(x => x.PostId))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId))
                   .ForMember(x => x.Status, y => y.MapFrom(x => x.Status)));

            return new Mapper(config);
        }

        protected override Mapper DtoModelToVMModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NotificationDtoModel, NotificationViewModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.PostId, y => y.MapFrom(x => x.PostId))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId))
                   .ForMember(x => x.Status, y => y.MapFrom(x => x.Status)));

            return new Mapper(config);
        }
    }
}
