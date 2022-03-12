using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Profiles
{
    public class SubscriptionProfile : BaseProfile<SubscriptionDtoModel, SubscritptionEntityModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public SubscriptionProfile(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SubscriptionDtoModel, SubscritptionEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId)));
            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SubscritptionEntityModel, SubscriptionDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId)));

            return new Mapper(config);
        }
    }
}
