using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Services;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Profiles
{
    public class PostProfile : BaseProfile<PostDtoModel, PostEntityModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public PostProfile(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override Mapper DtoModelToEntityModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostDtoModel, PostEntityModel>()
                   .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Text, y => y.MapFrom(x => x.Text))
                   .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId)));

            return new Mapper(config);
        }

        protected override Mapper EntityModelToDtoModelMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PostEntityModel, PostDtoModel>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                   .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                   .ForMember(x => x.Text, y => y.MapFrom(x => x.Text))
                   .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreateDate))
                   .ForMember(x => x.WebPortalId, y => y.MapFrom(x => x.WebPortalId)));

            return new Mapper(config);
        }
    }
}
