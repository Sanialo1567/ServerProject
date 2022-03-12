using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Profiles
{
    public class NotificationProfile : BaseProfile<NotificationDtoModel, NotificationEntityModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public NotificationProfile(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NotificationDtoModel, NotificationEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.PostId, y => y.MapFrom(x => x.PostId))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId))
                   .ForMember(x => x.Status, y => y.MapFrom(x => x.Status)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NotificationEntityModel, NotificationDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.PostId, y => y.MapFrom(x => x.PostId))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId))
                   .ForMember(x => x.Status, y => y.MapFrom(x => x.Status)));

            return new Mapper(config);
        }
    }
}
